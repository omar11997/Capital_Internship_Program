using System.Net;
using CapitalInternshipProgram.DTO;
using CapitalInternshipProgram.Model;
using Microsoft.Azure.Cosmos;

namespace CapitalInternshipProgram.Containers
{
    
    public class ProgramContainer<T> where T : class
    {
        private readonly Container _container;
        public ProgramContainer(CosmosDbSettings cosmosDbSettings)
        {
            var client = new CosmosClient(cosmosDbSettings.ConnectionString);
            _container = client.GetContainer(cosmosDbSettings.DatabaseName, cosmosDbSettings.ContainerName);
        }
        public async Task<IEnumerable<T>> GetAllPrograms()
        {
            var query = _container.GetItemQueryIterator<T>(new QueryDefinition("SELECT * FROM c"));
            List<T> results = new List<T>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }

            return results;
        }
        public async Task<MyProgram> GetItemAsync(string Id)
        {

            try
            {
                ItemResponse<MyProgram> response = await _container.ReadItemAsync<MyProgram>(Id, new PartitionKey(Id));
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Resource;
                }
                else
                {

                    return null;
                }
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }
        public async Task<MyProgram> AddProgram(MyProgram program)
        {
            try
            {
                ItemResponse<MyProgram> response = await _container.CreateItemAsync(program);
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }
        }
        public async Task<MyProgram> updateProgram(string id, MyProgram newProgram)
        {
            try
            {
                var response = await _container.ReplaceItemAsync(newProgram, id, new PartitionKey(id));
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Resource;
                }
                return null;

            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }


        }

    }
}
