using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Dynamic;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string username, string password)
        {
            var result = DataAccessFactory.AuthData().Authenticate(username, password);
            if (result)
            {
                //var existingTokent = DataAccessFactory.TokenData().Get();
                var token = new Token();
                token.Username = username;
                token.CreatedAt = DateTime.Now;
                //token.DeletedAt = DateTime.Now.AddHour(1);
                token.TKey = Guid.NewGuid().ToString().Substring(1, 10);

                var ret = DataAccessFactory.TokenData().Create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }
                if (DataAccessFactory.UserData().Get(username).Role == "Doctor")
                {
                    var result1 = DataAccessFactory.MatchData().Match(username);

                    token.Id = result1.Id;
                }
                if (DataAccessFactory.UserData().Get(username).Role == "Patient")
                {
                    var result1 = DataAccessFactory.MatchData1().Match(username);

                    token.Id = result1.Id;
                }
                if (DataAccessFactory.UserData().Get(username).Role == "Pharmacy")
                {
                    var result1 = DataAccessFactory.MatchData2().Match(username);

                    token.Id = result1.Id;
                }

                DataAccessFactory.TokenData().Update(token);

            }
            return null;
        }
      

        public static bool IsTokenValid (string TKey)
        {
            var existingToken = DataAccessFactory.TokenData().Get(TKey);
            if (existingToken != null && existingToken.DeletedAt == null)
            {
                return true;
            }
            return false;
        }

        public static bool Logout (string TKey)
        {
            var existingToken = DataAccessFactory.TokenData().Get(TKey);
            existingToken.DeletedAt = DateTime.Now;
            if (DataAccessFactory.TokenData().Update(existingToken) != null)
            {
                return true;
            }
            return false;
        }

        public static bool IsDoctor (string TKey)
        {
            var existingToken = DataAccessFactory.TokenData().Get(TKey);
            if (IsTokenValid(TKey) && existingToken.User.Role.Equals("Doctor"))
            {
                return true;
            }
            return false;
        }

        public static bool IsPatient (string TKey)
        {
            var existingToken = DataAccessFactory.TokenData().Get(TKey);
            if (IsTokenValid(TKey) && existingToken.User.Role.Equals("Patient"))
            {
                return true;
            }
            return false;
        }

        public static bool IsPharmacy (string TKey)
        {
            var existingToken = DataAccessFactory.TokenData().Get(TKey);
            if (IsTokenValid(TKey) && existingToken.User.Role.Equals("Pharmacy"))
            {
                return true;
            }
            return false;
        }
    }
}
