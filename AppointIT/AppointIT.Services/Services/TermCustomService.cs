using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Models;

namespace AppointIT.Services
{
    public class TermCustomService: ITermCustomService
    {
        public MyContext _context { get; set; }
        public IMapper _mapper { get; set; }
        public TermCustomService(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.Models.TermCustom Get(int id)
        {
            var entity = _context.Terms.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<TermCustom>(entity);
        }
    }
}
