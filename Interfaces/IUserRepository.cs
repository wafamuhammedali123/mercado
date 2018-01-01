using System.Collections.Generic;
using mercado.Model;

namespace mercado.Interfaces
{
    public interface IUserRepository
{
    void Add(UserModel item);
  
    void Update(UserModel item);
    UserModel Login(UserModel item);
     

}
}