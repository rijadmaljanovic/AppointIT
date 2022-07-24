
using AppointIT.Model;
using AppointIT.Model.Requests;

namespace AppointIT.Services.Interfaces
{
    public interface ICouponService : ICrudService<Coupon, CouponSearchObject, CouponInsertRequest, CouponInsertRequest>
    {

    }
}
