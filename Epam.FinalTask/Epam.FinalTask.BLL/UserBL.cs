using Epam.FinalTask.BLL.Interfaces;
using Epam.FinalTask.DAL.Interfaces;
using Epam.FinalTask.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Hosting;

namespace Epam.FinalTask.BLL
{
    public class UserBL : IUserBL
    {
        private IUserDao _userDao;
        public UserBL(IUserDao userDao) 
        {
            _userDao = userDao;
        }
        public UserDTO Add(UserDTO userDTO)
        {
            User user = new User()
            {
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
                string fileName = Guid.NewGuid().ToString();
                string hostingPath = HostingEnvironment.MapPath("~");
                string imagePath = Path.Combine("Images", fileName);
                string fullPath = Path.Combine(hostingPath, imagePath);
                File.WriteAllBytes(fullPath, userDTO.Avatar);
                user.ImagePath = imagePath;
            }

            user = _userDao.Add(user);
            userDTO.ID = user.ID;
            return userDTO;
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
            User user = _userDao.GetById(id);
            return CreateUserDTO(user);
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
            string hostingPath = HostingEnvironment.MapPath("~");
            byte[] avatar = File.ReadAllBytes(Path.Combine(hostingPath, user.ImagePath));
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
    }
}
