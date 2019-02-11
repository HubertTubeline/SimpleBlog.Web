using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SimpleBlog.DAL.EF.Entities;
using SimpleBlog.DAL.Repositories;
using SimpleBlog.Web.Models.Account;
using SimpleBlog.Web.Utils;

namespace SimpleBlog.Web.Services
{
    public class AccountService
    {
        readonly UserRepository _repository;

        public AccountService()
        {
            _repository = new UserRepository();
        }

        public User GetUser(IPrincipal user)
        {
            return _repository.Get(user.Identity.GetUserId<string>());
        }

        public bool IsEmailFree(string email)
        {
            var isFind = _repository.FindEmail(email);
            return !isFind;
        }

        public void ForgotPassword(string email)
        {
            // TODO: Implement this functionality
        }

        public void UpdateLastVisitTime(AccountViewModel model)
        {
            var user = _repository.Get(model.Id);
            user.LatestVisit = DateTimeOffset.UtcNow;
            _repository.Update(user);
        }

        public void UpdateUserInfo(AccountViewModel model)
        {
            var user = Mapper.MapUser(model);
            _repository.Update(user);
        }

        public void DeleteUser(AccountViewModel model)
        {

        }

        public async Task<ClaimsIdentity> Login(LoginViewModel model)
        {
            return await _repository.AuthAsync(model.Email, model.Password);
        }

        public async Task<IdentityResult> Register(RegisterViewModel model)
        {
            if (!model.Password.Equals(model.PasswordConfirm)) return new IdentityResult("Passwords don't match");

            var user = new User
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
            };
            return await _repository.CreateUserAsync(user, model.Password);
        }
    }
}