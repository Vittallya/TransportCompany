using AutoMapper;
using Models;
using System.Linq;
using TransportCompany.ViewModels;

namespace TransportCompany.Services
{
    public class UserService
    {
        private readonly DbContextLocal db;
        private readonly Mapper mapper;

        public bool IsAutorized { get; private set; }
        public UserViewModel CurrentUser { get; private set; }

        public Models.UserGroup UserGroup { get; private set; }

        public UserService(DbContextLocal db, Mapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        public AutorizeResult TryAutorize(UserViewModel data)
        {

            var user = db.Users.FirstOrDefault(u => u.Login.Equals(data.Login) && u.Password.Equals(data.Password));

            if (user == null)
            {
                return new AutorizeResult { Message = "Пользователь не найден", Res = false };
            }

            IsAutorized = true;
            CurrentUser = mapper.Map<User, UserViewModel>(user);

            return new AutorizeResult { Res = true };
        }
    }


    public class AutorizeResult
    {
        public string Message { get; init; }
        public bool Res { get; init; }
    }
}
