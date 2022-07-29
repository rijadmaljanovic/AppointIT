using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Model.Models;

namespace AppointIT.Services.Interfaces
{
    public interface ICustomerServiceRecommendService
    {
        List<CustomerServiceRecommend> Get(int CustomerId);
    }
}
