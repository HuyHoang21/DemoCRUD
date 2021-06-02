using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DemoUI.Commons;
using DemoUI.IService;
using DemoUI.Models;

namespace DemoUI.Services
{
  public class AccountService : IAccountService
  {
    AccountModels _oAccount = new AccountModels();
    public bool Delete(int id)
    {
      _oAccount = new AccountModels();
      try
      {
        using IDbConnection con = new SqlConnection(Global.ConnectionString);
        if (con.State == ConnectionState.Closed) con.Open();
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
        var sql = "DELETE FROM [Account] WHERE ID = @Id;";
        var oAccounts = con.Query<AccountModels>(sql, parameters);
        con.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }
      return true;
    }

    public AccountModels Get(int Id)
    {
      _oAccount = new AccountModels();
      try
      {
        using IDbConnection con = new SqlConnection(Global.ConnectionString);
        if (con.State == ConnectionState.Closed) con.Open();
        DynamicParameters parameter = new DynamicParameters();
        parameter.Add("@id", Id);
        var _oAccounts = con.Query<AccountModels>("SELECT ID,Username,Role FROM [Account] WHERE ID = @id", parameter).ToList();
        if (_oAccounts != null && _oAccounts.Count() > 0)
        {
          _oAccount = _oAccounts.SingleOrDefault();
        }
        con.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return null;
      }
      return _oAccount;
    }

    public bool Insert(LoginModels oAccount)
    {
      _oAccount = new AccountModels();
      try
      {
        using IDbConnection con = new SqlConnection(Global.ConnectionString);
        if (con.State == ConnectionState.Closed) con.Open();
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@Username", oAccount.Username);
        parameters.Add("@Password", oAccount.Password);
        Dapper.SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);   // Change Default String Handling to AnsiString
        var oAccounts = con.Query<AccountModels>("INSERT INTO [Account] VALUES(@Username,HASHBYTES('SHA2_256',@Password))", parameters);
        con.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }
      return true;
    }
    public AccountType Login(LoginModels oLogin)
    {
      var _oType = new AccountType();
      try
      {
        using IDbConnection con = new SqlConnection(Global.ConnectionString);
        if (con.State == ConnectionState.Closed) con.Open();
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@Username", oLogin.Username);
        parameters.Add("@Password", oLogin.Password);
        Dapper.SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);   // Change Default String Handling to AnsiString
        var _oLogin = con.Query<AccountType>("SELECT ID FROM LoginDB..Account WHERE Username = @Username AND Password = HASHBYTES('SHA2_256',@Password)", parameters).ToList();
        if (_oLogin != null && _oLogin.FirstOrDefault().Id != 0)
        {
          _oType = _oLogin.FirstOrDefault();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        _oType.Id = 0;
        return _oType;
      }
      return _oType;
    }

  }

}
