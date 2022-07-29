using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Model.Models;
using AppointIT.Model.Requests;


namespace AppointIT.Services.Interfaces
{
    public interface INewsService:ICrudService<News,NewsSearchObject, NewsInsertRequest, NewsInsertRequest>
    {

    }
}
