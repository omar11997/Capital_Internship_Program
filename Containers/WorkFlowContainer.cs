using System.Net;
using CapitalInternshipProgram.Model;
using Microsoft.Azure.Cosmos;
namespace CapitalInternshipProgram.Containers
{
    public class WorkFlowContainer<T> where T : class
    {
        private readonly Container? _container;
        public WorkFlowContainer(CosmosDbSettings cosmosDbSettings)
        {
            var client = new CosmosClient(cosmosDbSettings.ConnectionString);
            _container = client.GetContainer(cosmosDbSettings.DatabaseName, cosmosDbSettings.ContainerName);
        }
        public async Task<WorkFlow> GetItemAsync(string ProgrameId)
        {

            try
            {
                ProgrameId = ProgrameId.Replace("'", "''");
                var queryText = "SELECT * FROM c WHERE c.ProgramId = @ProgrameId";
                var queryDefinition = new QueryDefinition(queryText).WithParameter("@ProgrameId", ProgrameId);
                var query = _container.GetItemQueryIterator<WorkFlow>(queryDefinition);

                List<WorkFlow> results = new List<WorkFlow>();

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
        public async Task<WorkFlow> UpdateWorkFlow(string id, WorkFlow newWorkFlow)
        {
            try
            {
                var response = await _container.ReplaceItemAsync(newWorkFlow, id, new PartitionKey(id));
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
        public async Task<WorkFlow> GetWorkFlowById(string id)
        {
            try
            {
                ItemResponse<WorkFlow> response = await _container.ReadItemAsync<WorkFlow>(id, new PartitionKey(id));
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
