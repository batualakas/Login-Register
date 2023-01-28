using Project.Business.Types;
using Project.Data.Dto;
using Project.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Services
{
    public interface IUserService
    {
        ServiceMessage AddUser(UserEntity user);
        UserEntity Login(string email,string password);
        UserEntity GetUserById(int id);
        void UpdateUser(UserDto user);
    }
}
