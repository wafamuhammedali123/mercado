using System.Collections.Generic;
using mercado.Model;

namespace mercado.Interfaces
{
    public interface ICouponRepository
{
    IEnumerable<CouponModel> GetAll();
    void Add(CouponModel item);
  
    void Update(CouponModel item);
     

}
}