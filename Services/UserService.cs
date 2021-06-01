using System;
using System.Collections.Generic;
using System.Data;
using DemoUI.Commons;
using DemoUI.IService;
using DemoUI.Models;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace DemoUI.Services
{
  public class UserService : IUserService
  {
    UserModel _oUser = new UserModel();
    List<UserModel> _oUsers = new List<UserModel>();
    public UserModel Delete(int id)
    {
      _oUser = new UserModel();
      try
      {
        using IDbConnection con = new SqlConnection(Global.ConnectionString);
        if (con.State == ConnectionState.Closed) con.Open();
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@Id", id);
        var sql = "DELETE FROM [User] WHERE Id = @Id;";
        var oUsers = con.Query<UserModel>(sql, parameters);
        con.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return _oUser;
    }

    public List<UserModel> Get()
    {
      _oUsers = new List<UserModel>();
      try
      {
        using IDbConnection con = new SqlConnection(Global.ConnectionString);
        if (con.State == ConnectionState.Closed) con.Open();
        _oUsers = con.Query<UserModel>("SELECT * FROM [User]").ToList();
        con.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return _oUsers;
    }

    public UserModel Get(int Id)
    {
      _oUser = new UserModel();
      try
      {
        using IDbConnection con = new SqlConnection(Global.ConnectionString);
        if (con.State == ConnectionState.Closed) con.Open();
        DynamicParameters parameter = new DynamicParameters();
        parameter.Add("@id", Id, DbType.Int32, ParameterDirection.Input);
        var _oUsers = con.Query<UserModel>("SELECT * FROM [User] WHERE Id = @id", parameter).ToList();
        if (_oUsers != null && _oUsers.Count() > 0)
        {
          _oUser = _oUsers.SingleOrDefault();
        }
        con.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return _oUser;
    }

    public UserModel Insert(UserModel oUser)
    {
      _oUser = new UserModel();
      try
      {
        using IDbConnection con = new SqlConnection(Global.ConnectionString);
        if (con.State == ConnectionState.Closed) con.Open();
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@FirstName", oUser.FirstName);
        parameters.Add("@LastName", oUser.LastName);
        parameters.Add("@Username", oUser.Username);
        var sql = "INSERT INTO [User] VALUES(@FirstName,@LastName,@Username)";
        var oUsers = con.Query<UserModel>(sql, parameters);
        con.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return _oUser;
    }
  }
}
