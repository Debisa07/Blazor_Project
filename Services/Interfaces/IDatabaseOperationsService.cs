namespace DBExplorer.Web.Services.Interfaces
{
  public interface IDatabaseOperationsService
  {
    // Table Data Operations
    Task<bool> AddTableRowAsync(string tableName, Dictionary<string, object> newRow);
    Task<bool> UpdateTableRowAsync(string tableName, Dictionary<string, object> updatedRow);
    Task<bool> DeleteTableRowAsync(string tableName, object rowId);
  }
}
