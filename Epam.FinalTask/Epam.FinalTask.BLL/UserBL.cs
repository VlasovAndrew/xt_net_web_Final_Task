using Epam.FinalTask.BLL.Interfaces;
using Epam.FinalTask.DAL.Interfaces;
using Epam.FinalTask.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Hosting;
using Epam.FinalTask.Logger;

namespace Epam.FinalTask.BLL
{
    public class UserBL : IUserBL
    {
        private IUserDao _userDao;
        private ILog _logger = Logger.Logger.Log;
        public UserBL(IUserDao userDao) 
        {
            _userDao = userDao;
        }
        public UserDTO Add(UserDTO userDTO)
        {
            User user = CreateUser(userDTO);
            user = _userDao.Add(user);
            userDTO.ID = user.ID;
            return userDTO;
        }

        public void AddFriend(int userID, int friendID)
        {
            _userDao.AddFriend(userID, friendID);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            List<UserDTO> res = new List<UserDTO>();
            IEnumerable<User> users = _userDao.GetAll();
            foreach (var user in users)
            {
                res.Add(CreateUserDTO(user));
            }
            return res;
        }

        public UserDTO GetById(int id)
        {
            _logger.Info($"Getting user with id = {id}");
            User user;
            try {
                user = _userDao.GetById(id);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e.Message, e);
                throw;
            }
            
            return CreateUserDTO(user);
        }

        public void RemoveFriend(int userID, int friendID)
        {
            _userDao.DeleteFriend(userID, friendID);
        }

        public IEnumerable<UserDTO> Search(Dictionary<string, string> searchParams)
        {
            IEnumerable<UserDTO> users = GetAll();
            searchParams.TryGetValue("name", out var searchName);
            if (searchName != null && searchName != "")
            {
                users = users.Where(user => user.Name.ToLower() == searchName.ToLower());
            }

            searchParams.TryGetValue("surname", out var searchSurname);
            if (searchSurname != null && searchSurname != "") {
                users = users.Where(user => user.Surname.ToLower() == searchSurname.ToLower());
            }

            searchParams.TryGetValue("city", out var searchCity);
            if (searchCity != null && searchCity != "") {
                users = users.Where(user => user.City.ToLower() == searchCity.ToLower());
            }

            searchParams.TryGetValue("house", out var searchHouse);
            if (searchHouse != null && searchHouse != "") {
                users = users.Where(user => user.HouseNumber == searchHouse);
            }

            DateTime today = DateTime.Today;
            searchParams.TryGetValue("lowerAgeBound", out var lowerAgeBoundStr);
            if (lowerAgeBoundStr != null && int.TryParse(lowerAgeBoundStr, out var lowerAgeNumber)) {
                users = users.Where(user => CalculateAge(user.Birthday, today) >= lowerAgeNumber);
            }

            searchParams.TryGetValue("upperAgeBound", out var upperAgeBoundStr);
            if (upperAgeBoundStr != null && int.TryParse(upperAgeBoundStr, out var upperAgeNumber)) {
                users = users.Where(user => CalculateAge(user.Birthday, today) <= upperAgeNumber);
            }

            return users;
        }

        public void Update(UserDTO userDTO)
        {
            // Get current user entity
            User currentUser = _userDao.GetById(userDTO.ID);
            // If user has profile image and updating entity has image, then delete old image
            if (currentUser.ImagePath != null && userDTO.Avatar != null)
            {
                DeleteImage(currentUser.ImagePath);
            }
            // Create new user entity from updating userDTO
            User updatedUser = CreateUser(userDTO);
            // If user has image and userDTO doesn't  have image then strore old profile image
            if (currentUser.ImagePath != null && userDTO.Avatar == null) {
                updatedUser.ImagePath = currentUser.ImagePath;
            }
            _userDao.Update(updatedUser);
        }

        public void Delete(int userID)
        {
            _userDao.DeleteById(userID);
        }

        private UserDTO CreateUserDTO(User user) 
        {
            List<User> friends = new List<User>();
            foreach (var friendId in user.Friends)
            {
                friends.Add(_userDao.GetById(friendId));
            }
            /// Check image path
            if (user.ImagePath == null)
            {
                user.ImagePath = ConfigurationManager.AppSettings["defaultUserImage"];
            }

            byte[] avatar = ReadImage(user.ImagePath, user.ID);
            UserDTO userDTO = new UserDTO()
            {
                ID = user.ID,
                Name = user.Name,
                Surname = user.Surname,
                Birthday = user.Birthday,
                City = user.City,
                Street = user.Street,
                HouseNumber = user.HouseNumber,
                ApartmentNumber = user.ApartmentNumber,
                Friends = user.Friends,
                Avatar = avatar,
            };
            return userDTO;
        }
        private User CreateUser(UserDTO userDTO) 
        {
            User user = new User()
            {
                ID = userDTO.ID,
                Name = userDTO.Name,
                Surname = userDTO.Surname,
                Birthday = userDTO.Birthday,
                City = userDTO.City,
                Street = userDTO.Street,
                HouseNumber = userDTO.HouseNumber,
                ApartmentNumber = userDTO.ApartmentNumber,
            };

            if (userDTO.Avatar != null)
            {
                user.ImagePath = SaveImage(userDTO.Avatar);
            }
            return user;
        }

        private string SaveImage(byte[] image)
        {
            string fileName = Guid.NewGuid().ToString();
            string hostingPath = HostingEnvironment.MapPath("~");
            string imagePath = Path.Combine("Images", fileName);
            string fullPath = Path.Combine(hostingPath, imagePath);
            File.WriteAllBytes(fullPath, image);
            return imagePath;
        }

        private byte[] ReadImage(string path, int userID)
        {
            string hostingPath = HostingEnvironment.MapPath("~");
            byte[] avatar;
            try
            {
                avatar = File.ReadAllBytes(Path.Combine(hostingPath, path));
            }
            catch (FileNotFoundException e) {
                avatar = new byte[] { };
                _logger.Error($"Cannot read profile image from user with id = {userID}", e);
            }
            return avatar;
        }

        private void DeleteImage(string path) 
        {
            string hostingPath = HostingEnvironment.MapPath("~");
            File.Delete(Path.Combine(hostingPath, path));
        }

        private int CalculateAge(DateTime birthday, DateTime today) {
            var age = today.Year - birthday.Year;
            if (birthday.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
