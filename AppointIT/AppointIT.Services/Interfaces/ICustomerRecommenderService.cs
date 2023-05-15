using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Model.Models;
using static AppointIT.Services.CustomerRecommenderService;

namespace AppointIT.Services.Interfaces
{
    public interface ICustomerRecommenderService
    {
        List<CustomerServiceRecommend> Recommend(int CustomerId);
        List<SalonCustom> SearchFilter(TermCustomSearchObject search = null);

    }
}
