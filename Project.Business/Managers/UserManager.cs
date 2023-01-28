using Microsoft.AspNetCore.DataProtection;
using Project.Business.Services;
using Project.Business.Types;
using Project.Data.Dto;
using Project.Data.Entities;
using Project.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Managers
{
    public class UserManager : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IDataProtector _dataProtector;

        public UserManager(IRepository<UserEntity> userRepository, IDataProtectionProvider dataProtectionProvider)
        {
            _userRepository = userRepository;
            _dataProtector = dataProtectionProvider.CreateProtector("security");
        }

        public ServiceMessage AddUser(UserEntity user)
        {
            var hasMail = _userRepository.GetAll(x => x.Email.ToLower() == user.Email.ToLower()).ToList(); //mail kontrol
            if (hasMail.Any()) //mail adresi kayıtlı mı kontrolü
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu Email adresi kayıtlıdır. Lütfen farklı bir Email adresi giriniz"
                };
            }
            user.Password = _dataProtector.Protect(user.Password);
            _userRepository.Add(user);
            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        public UserEntity GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public UserEntity Login(string email, string password)
        {
            var user = _userRepository.Get(x => x.Email == email);
            if (user is null)
            {
                return null;
                 
            }
            // şifreyi korumasız hale getirmemiz gerekiyor çünkü sql serverdan gelen şifre ile view üzerinde girdiğimiz şifre aynı mı kontrolü yapılmalı.
            var rawPassword = _dataProtector.Unprotect(user.Password);
            if (rawPassword!=password)
            {
                return null;
            }
            return user;
            

        }

        public void UpdateUser(UserDto user)
        {
            var userEntity = _userRepository.GetById(user.Id);
            userEntity.FirstName = user.FirstName;
            userEntity.LastName = user.LastName;
            userEntity.Email = user.Email;

            _userRepository.Update(userEntity);
        }
    }
}
