using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizApp.Services.Data;

namespace QuizApp.Services.Business
{
    public class SecurityService
    {
        CheckUserInput daoService = new CheckUserInput();

        public UserModel Authenticate(UserModel userModel)
        {
            return daoService.FindByUser(userModel);
        }

        public bool Registrate(RegisterModel Register)
        {
            return daoService.StoreUser(Register);
        }
    }
}