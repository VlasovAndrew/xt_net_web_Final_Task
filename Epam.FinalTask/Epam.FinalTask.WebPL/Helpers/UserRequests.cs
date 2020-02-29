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
        public static string AddUser(string nameParam, 
            string surnameParam, 
            string birthdayParam, 
            string cityParam, 
            string streetParam, 
            string houseParam, 
            string apartmentParam,
            byte[] avatar) 
        {
            if (nameParam == null || nameParam == "") {
                return "Введите имя";
            }

            if (surnameParam == null || surnameParam == "") {
                return "Введите фамилию";
            }

            if (birthdayParam == null)
            {
                return "Введите дату рождения";
            }

            if (!DateTime.TryParse(birthdayParam, out var birthday)) {
                return "Введите корректную дату";
            }

            if (cityParam == null || cityParam == "") {
                return "Введите город";
            }

            if (streetParam == null || streetParam == "") {
                return "Введите улицу";
            }

            if (houseParam == null || houseParam == "") {
                return "Введите номер дома";
            }

            UserDTO userDTO = new UserDTO();

            userDTO.Name = nameParam;
            userDTO.Surname = surnameParam;
            userDTO.City = cityParam;
            userDTO.Birthday = birthday;
            userDTO.Street = streetParam;
            userDTO.HouseNumber = houseParam;
            userDTO.Avatar = avatar;

            if (apartmentParam != null)
            {
                if (!int.TryParse(apartmentParam, out var apartmentNumber) 
                    || apartmentNumber <= 0
                    || apartmentNumber >= 1000) {
                    return "Введите корректный номер квартиры";
                }
                userDTO.ApartmentNumber = apartmentNumber;
            }

            _userBL.Add(userDTO);
            return null;
        }
    }
}