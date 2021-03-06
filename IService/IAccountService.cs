using System;
using DemoUI.Models;

namespace DemoUI.IService
{
  public interface IAccountService
  {
    bool Insert(LoginModels oAccount);
    bool Delete(int id);
    AccountModels Get(int Id);
    public AccountType Login(LoginModels oLogin);
  }
}
