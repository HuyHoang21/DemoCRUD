using System;
namespace DemoUI.Models
{
  public class AccountModels
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
  }
  public class LoginModels
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }
  public class AccountType
  {
    public int Id { get; set; }
  }
}
