using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Epam.FinalTask.BLL.Interfaces;
using Epam.FinalTask.Entities;
using Epam.FinalTask.Ioc;

namespace Epam.FinalTask.WebPL.Helpers
{
    public static class UserRequests
    {
        private static IUserBL _userBL = DependencyResolver.UserBL;
        private static IAccountBL _accountBL = DependencyResolver.AccountBL;

        public static Tuple<string, UserDTO> CreateUser(HttpRequestBase request) {
            string name = request.Form["name"];
            string surname = request.Form["surname"];
            string birthday = request.Form["birthday"];
            string city = request.Form["city"];
            string street = request.Form["street"];
            string house = request.Form["house"];
            string apartment = request.Form["apartment"];
            byte[] photo = WebImage.GetImageFromRequest()?.GetBytes();
            return CreateUser(name, surname, birthday, city, street, house, apartment, photo);
        }

        public static Tuple<string, UserDTO> CreateUser(string nameParam, 
            string surnameParam, 
            string birthdayParam, 
            string cityParam, 
            string streetParam, 
            string houseParam, 
            string apartmentParam,
            byte[] avatar)
        {
            if (nameParam == null || nameParam == "") {
                return new Tuple<string, UserDTO>("Введите имя", null);
            }

            if (surnameParam == null || surnameParam == "") {
                return new Tuple<string, UserDTO>("Введите фамилию", null);
            }

            if (birthdayParam == null)
            {
                return new Tuple<string, UserDTO>("Введите дату рождения", null);
            }

            if (!DateTime.TryParse(birthdayParam, out var birthday)) {
                return new Tuple<string, UserDTO>("Введите корректную дату", null);
            }

            if (birthday > DateTime.Today) {
                return new Tuple<string, UserDTO>("Дата рождения не может быть больше сегднешней даты", null);
            }

            if (birthday.Year <= 1900) {
                return new Tuple<string, UserDTO>("Похоже, что Вы ввели неверный год рождения", null);
            }

            if (cityParam == null || cityParam == "") {
                return new Tuple<string, UserDTO>("Введите город", null);
            }

            if (streetParam == null || streetParam == "") {
                return new Tuple<string, UserDTO>("Введите улицу", null);
            }

            if (houseParam == null || houseParam == "") {
                return new Tuple<string, UserDTO>("Введите номер дома", null);
            }
            UserDTO userDTO = new UserDTO();

            if (apartmentParam != null && apartmentParam != "")
            {
                if (!int.TryParse(apartmentParam, out var apartmentNumber) 
                    || apartmentNumber <= 0
                    || apartmentNumber >= 500) {
                    return new Tuple<string, UserDTO>("Введите корректный номер квартиры", null);
                }
                userDTO.ApartmentNumber = apartmentNumber;
            }

            userDTO.Name = nameParam;
            userDTO.Surname = surnameParam;
            userDTO.City = cityParam;
            userDTO.Birthday = birthday;
            userDTO.Street = streetParam;
            userDTO.HouseNumber = houseParam;
            userDTO.Avatar = avatar;

            return new Tuple<string, UserDTO> (null, userDTO);
        }

        public static Tuple<string, Account> CreateAccount(string login, string password)
        {
            if (_accountBL.AccountExists(login)) {
                return 
                    new Tuple<string, Account>("Аккаунт с таким логином уже существует, пожалуйста " +
                                                    "выберите другой логин другой", null);
            }

            if (login == "" || login == null) 
            {
                return new Tuple<string, Account>("Введите логин", null);
            }

            if (password == "" || password == null)
            {
                return new Tuple<string, Account>("Введите пароль", null);
            }

            if (password.Length < 5 || password.Length > 10) {
                return new Tuple<string, Account>("Пароль должен быть длиной от 5 до 10 символов", null);
            }

            Account account = _accountBL.СreateAccount(login, password);
            return new Tuple<string, Account>(null, account);
        }

        public static void CreateAccountWithUser(Account account, UserDTO user)
        {
            user = _userBL.Add(user);
            account = _accountBL.Add(account);
            _accountBL.AttachUserToAccount(account.Login, user.ID);
        }

        public static string MakeImageString(byte[] image)
        {
            if (image.Length == 0)
                return null;
            return $"data:image;base64, {Convert.ToBase64String(image)}";
        }
    }
}