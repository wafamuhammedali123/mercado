using System.Collections.Generic;
using mercado.Model;

namespace mercado.Interfaces
{
    public interface IShopRepository
{
    IEnumerable<ShopModel> GetAll();
    void Add(ShopModel item);
  
    void Update(ShopModel item);
     

}
}