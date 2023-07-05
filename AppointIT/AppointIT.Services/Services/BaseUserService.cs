using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AppointIT.Services.Filters;
using Microsoft.EntityFrameworkCore;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Enumerations;
using AppointIT.Model.Requests;
using AppointIT.Model.Models;

namespace AppointIT.Services
{
    public class BaseUserService : IBaseUserService
    {
        private readonly MyContext _context;
        protected readonly IMapper _mapper;

        public BaseUserService(MyContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public Model.Models.BaseUser GetById(int id)
        {
            var entity = _context.BaseUsers.Find(id);

            return _mapper.Map<Model.Models.BaseUser>(entity);
        }
        public Model.Models.BaseUser Insert(BaseUserInsertRequest request)
        {
            var entity = _mapper.Map<Database.BaseUser>(request);
            _context.Add(entity);

            if (request.Password != request.ConfirmPassword)
            {
                throw new UserException("Lozinka se razlikuje od potvrde");
            }

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            entity.CreatedAt = DateTime.Now;

            _context.SaveChanges();

            Database.BaseUserRole baseUserRole = new Database.BaseUserRole();
            baseUserRole.BaseUserId = entity.Id;
            baseUserRole.RoleId = request.RoleId;

            _context.BaseUserRoles.Add(baseUserRole);

            _context.SaveChanges();

            return _mapper.Map<Model.Models.BaseUser>(entity);
        }
        public Model.Models.BaseUser Update(int Id, BaseUserInsertRequest request)
        {
            var set = _context.Set<AppointIT.Services.Database.BaseUser>();
            var entity = set.Find(Id);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Models.BaseUser>(entity);
        }
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        public async Task<Model.Models.BaseUser> Login(string email, string password)
        {
            try
            {
                var entity = await _context.BaseUsers.Include("BaseUserRoles.Role").FirstOrDefaultAsync(x => x.Email == email);

                if (entity == null)
                {
                    throw new UserException("Pogrešan username ili password");
                }
                var hash = GenerateHash(entity.PasswordSalt, password);

                if (hash != entity.PasswordHash)
                {
                    throw new UserException("Pogrešan username ili password");
                }

                return _mapper.Map<Model.Models.BaseUser>(entity);

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<Model.Models.BaseUser> GetAll()
        {
            var query = _context.BaseUsers.AsQueryable();

            var entities = query.ToList();
            return _mapper.Map<IEnumerable<Model.Models.BaseUser>>(entities);
        }
        public Model.Models.BaseUser Register(BaseUserInsertRequest request)
        {
            var entity = _mapper.Map<Database.BaseUser>(request);
            _context.Add(entity);

            entity.isActive = true;
            entity.CreatedAt = DateTime.Now;
            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            _context.SaveChanges();

            _context.Customers.Add(new AppointIT.Services.Database.Customer { Id = entity.Id });

            Database.BaseUserRole baseUserRole = new Database.BaseUserRole();
            baseUserRole.BaseUserId = entity.Id;
            baseUserRole.RoleId = request.RoleId;

            _context.BaseUserRoles.Add(baseUserRole);

            _context.SaveChanges();

            return _mapper.Map<Model.Models.BaseUser>(entity);
        }
    }
}
