﻿using Epam.FinalTask.BLL.Interfaces;
using Epam.FinalTask.DAL.Interfaces;
using Epam.FinalTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.BLL
{
    public class AccountBL : IAccountBL
    {
        private readonly IAccountDao _accountDao;
        private readonly int saltSize = 12;
        private readonly int hashSize = 20;
        private readonly int iterations = 10000;

        public AccountBL(IAccountDao accountDao)
        {
            _accountDao = accountDao;
        }
        public bool AddAccount(string login, string password, int userID = 0)
        {
            bool accountExists = _accountDao.AccountExists(login);
            if (accountExists) {
                return false;
            }

            Account account = new Account()
            {
                Login = login,
                Password = CreatePassword(password),
                UserID = userID,
            };

            _accountDao.Add(account);
            return true;
        }
        public void AttachUserToAccount(string login, int userID)
        {
            _accountDao.AttachUserToAccount(login, userID);
        }
        public bool CheckPassword(string login, string password)
        {
            Account account = _accountDao.GetAccountByLogin(login);

            byte[] salt = GetSaltFromHash(account.Password);
            byte[] checkingPassword = HashPassword(password, salt);
            for (int i = 0; i < checkingPassword.Length; i++)
            {
                if (checkingPassword[i] != account.Password[i])
                {
                    return false;
                }
            }
            return true;
        }


        private byte[] GetSaltFromHash(byte[] hash)
        {
            byte[] salt = new byte[saltSize];
            Array.Copy(hash, 0, salt, 0, saltSize);
            return salt;
        }

        private byte[] CreatePassword(string password)
        {
            byte[] salt = new byte[saltSize];
            new RNGCryptoServiceProvider().GetBytes(salt);
            return HashPassword(password, salt);
        }

        private byte[] HashPassword(string password, byte[] salt) 
        {
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[saltSize]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(hashSize);

            byte[] result = new byte[saltSize + hashSize];
            Array.Copy(salt, 0, result, 0, saltSize);
            Array.Copy(hash, 0, result, saltSize, hashSize);

            return result;
        }
    }
}
