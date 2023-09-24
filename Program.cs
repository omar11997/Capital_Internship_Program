
using CapitalInternshipProgram.Containers;
using CapitalInternshipProgram.Model;

namespace CapitalInternshipProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //////Congigure Prgram Container 
            var cosmosDbSettingsProgram = builder.Configuration.GetSection("CosmosDBSettingsProgram")
                                       .Get<CosmosDbSettings>();
            // builder.Services.AddSingleton(cosmosDbSettings);
            builder.Services.AddSingleton(provider =>
            {
                return new ProgramContainer<MyProgram>(cosmosDbSettingsProgram);
            });
            /////Configure App Template Container
            var cosmosDbSettingsTemplate = builder.Configuration.GetSection("CosmosDBSettingsTemplate").Get<CosmosDbSettings>();
            builder.Services.AddSingleton(provider =>
            {
                return new ApplicationTempContainer<AppTemp>(cosmosDbSettingsTemplate);
            });
            ////Configure WorkFlow Container 
            var cosmosDbSettingsWorkFlow = builder.Configuration.GetSection("CosmosDBSettingsWorkFlow").Get<CosmosDbSettings>();
            builder.Services.AddSingleton(provider =>
            {
                return new WorkFlowContainer<WorkFlow>(cosmosDbSettingsWorkFlow);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}