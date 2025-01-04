using DBExplorer.Web.Services.Interfaces;

namespace DBExplorer.Web.Services
{
  public class QueryService : IQueryService
  {
    private readonly HttpClient _httpClient;
    public QueryService(HttpClient httpClient) => _httpClient = httpClient;

    // Execute a SQL Query (tables, views)
    public async Task<string> ExecuteQueryAsync(string query)
    {
      try
      {
        var response = await _httpClient.PostAsJsonAsync("/api/query/execute", new { Query = query });

        if (response.IsSuccessStatusCode)
        {
          return await response.Content.ReadAsStringAsync();
        }
        else
        {
          throw new Exception($"Query execution failed: {response.ReasonPhrase}");
        }
      }
      catch (Exception ex)
      {
        throw new Exception($"Error executing query: {ex.Message}", ex);
      }
    }

    // Execute a Stored Procedure
    public async Task<string> ExecuteProcedureAsync(string procedureName, object parameters)
    {
      try
      {
        var response = await _httpClient.PostAsJsonAsync($"/api/procedures/{procedureName}/execute", parameters); // procedureName is unique

        if (response.IsSuccessStatusCode)
        {
          return await response.Content.ReadAsStringAsync();
        }
        else
        {
          throw new Exception($"Procedure execution failed: {response.ReasonPhrase}");
        }
      }
      catch (Exception ex)
      {
        throw new Exception($"Error executing procedure {procedureName}: {ex.Message}", ex);
      }
    }
  }
}
