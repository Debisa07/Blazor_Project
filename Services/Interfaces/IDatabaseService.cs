namespace DBExplorer.Web.Services.Interfaces
{
  public interface IDatabaseService
  {
    Task<List<string>> GetDatabases();
    Task<List<string>> GetTables(string databaseName);
    Task<List<string>> GetViews(string databaseName);
    Task<List<string>> GetProcedures(string databaseName);
  }

}
