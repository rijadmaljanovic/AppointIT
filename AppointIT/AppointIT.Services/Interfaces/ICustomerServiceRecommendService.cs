using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Model;

namespace AppointIT.Services.Interfaces
{
    public interface ICustomerServiceRecommendService
    {
        List<Model.CustomerServiceRecommend> Get(int CustomerId);
    }
}
