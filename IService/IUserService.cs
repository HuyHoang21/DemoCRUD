using System;
using System.Collections.Generic;
using DemoUI.Models;

namespace DemoUI.IService
{
  public interface IUserService
  {
    UserModel Insert(UserModel oUser);
    UserModel Delete(int id);
    List<UserModel> Get();
    UserModel Get(int Id);
  }
}
