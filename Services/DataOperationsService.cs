using DBExplorer.Web.Services.Interfaces;
namespace DBExplorer.Web.Services
{
  public class DataOperationsService : IDatabaseOperationsService
  {
    private readonly HttpClient _httpClient;
    public DataOperationsService(HttpClient httpClient) => _httpClient = httpClient;

    // Table Data Operations
    public async Task<bool> AddTableRowAsync(string tableName, Dictionary<string, object> newRow)
    {
      try
      {
        var response = await _httpClient.PostAsJsonAsync($"/api/tables/{tableName}/rows", newRow);
        return response.IsSuccessStatusCode;
      }
      catch (Exception ex)
      {
        throw new Exception($"Error adding row to table {tableName}: {ex.Message}", ex);
      }
    }

    public async Task<bool> UpdateTableRowAsync(string tableName, Dictionary<string, object> updatedRow)
    {
      try
      {
        var response = await _httpClient.PutAsJsonAsync($"/api/tables/{tableName}/rows", updatedRow);
        return response.IsSuccessStatusCode;
      }
      catch (Exception ex)
      {
        throw new Exception($"Error updating row in table {tableName}: {ex.Message}", ex);
      }
    }

    public async Task<bool> DeleteTableRowAsync(string tableName, object rowId)
    {
      try
      {
        var response = await _httpClient.DeleteAsync($"/api/tables/{tableName}/rows/{rowId}");
        return response.IsSuccessStatusCode;
      }
      catch (Exception ex)
      {
        throw new Exception($"Error deleting row from table {tableName}: {ex.Message}", ex);
      }
    }
  }
}
