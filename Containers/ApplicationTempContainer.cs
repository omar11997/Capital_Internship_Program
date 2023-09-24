using System.Net;
using CapitalInternshipProgram.Model;
using Microsoft.Azure.Cosmos;
namespace CapitalInternshipProgram.Containers
{
    public class ApplicationTempContainer<T> where T : class
    {
        private readonly Container _container;
        public ApplicationTempContainer(CosmosDbSettings cosmosDbSettings)
        {
            var client = new CosmosClient(cosmosDbSettings.ConnectionString);
            _container = client.GetContainer(cosmosDbSettings.DatabaseName, cosmosDbSettings.ContainerName);
        }
        public async Task<AppTemp> GetItemAsync(string ProgrameId)
        {

            try
            {
                ProgrameId = ProgrameId.Replace("'", "''");
                var queryText = "SELECT * FROM c WHERE c.ProgrameId = @ProgrameId";
                var queryDefinition = new QueryDefinition(queryText).WithParameter("@ProgrameId", ProgrameId);
                var query = _container.GetItemQueryIterator<AppTemp>(queryDefinition);
                
                List<AppTemp> results = new List<AppTemp>();

                while (query.HasMoreResults)
                {
                    var response = await query.ReadNextAsync();
                    results.AddRange(response);
                }
                if (results.Count > 0)
                {
                    return results[0];
                }
                return null;
               
                
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }
        public async Task<AppTemp> UpdateTemp(string id, AppTemp newTemp)
        {
            try
            {
                var response = await _container.ReplaceItemAsync(newTemp, id, new PartitionKey(id));
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
        public async Task<AppTemp> GetTempById(string id)
        {
            try
            {
                ItemResponse<AppTemp> response = await _container.ReadItemAsync<AppTemp>(id, new PartitionKey(id));
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
           
        

    }
}
