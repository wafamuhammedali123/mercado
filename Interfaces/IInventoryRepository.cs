using System.Collections.Generic;
using mercado.Model;

namespace mercado.Interfaces
{
    public interface IInventoryRepository
{
    IEnumerable<InventoryModel> GetAll();
    void Add(InventoryModel item);
  
    void Update(InventoryModel item);
     

}
}