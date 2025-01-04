namespace DBExplorer.Web.Services.Interfaces
{
  public interface IQueryService
  {
    // Execute a SQL Query (tables, views)
    Task<string> ExecuteQueryAsync(string query);

    // Execute a Stored Procedure
    Task<string> ExecuteProcedureAsync(string procedureName, object parameters);
  }
}
