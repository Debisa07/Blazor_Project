
using DBExplorer.Web.Services.Interfaces;
namespace DBExplorer.Web.Services
{
  public class DatabaseService : IDatabaseService
  {
    // TODO: Implement the IDatabaseService interface
    public async Task<List<string>> GetDatabases()
    {
      await Task.Delay(100);
      return
        [
            "Ignyte Dev",
            "Ignyte Staging"
        ];
    }

    // Simulate fetching tables for a given database
    public async Task<List<string>> GetTables(string databaseName)
    {
      await Task.Delay(100);

      if (databaseName == "Ignyte Dev")
      {
        return ["Users", "Orders", "Products", "Customers"];
      }
      else if (databaseName == "Ignyte Staging")
      {
        return ["Invoices", "Payments", "Suppliers", "Categories"];
      }

      return [];
    }

    // Simulate fetching views for a given database
    public async Task<List<string>> GetViews(string databaseName)
    {
      await Task.Delay(100);

      if (databaseName == "Ignyte Dev")
      {
        return ["OrderView", "CustomerView"];
      }
      else if (databaseName == "Ignyte Staging")
      {
        return ["PaymentView", "SupplierView"];
      }

      return [];
    }

    // Simulate fetching stored procedures for a given database
    public async Task<List<string>> GetProcedures(string databaseName)
    {
      await Task.Delay(100);

      if (databaseName == "Ignyte Dev")
      {
        return ["AddUserProcedure", "UpdateOrderStatusProcedure ad this is nice nice"];
      }
      else if (databaseName == "Ignyte Staging")
      {
        return ["ProcessPaymentProcedure", "UpdateSupplierInfoProcedure"];
      }

      return [];
    }
  }
}
