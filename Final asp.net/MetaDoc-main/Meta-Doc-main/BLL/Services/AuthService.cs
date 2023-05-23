using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BLL.Services
{
    public class AuthService
    {
        internal static string globalUsername;
        public static TokenDTO Authenticate1(string username, string password)
        {
            
            var result = DataAccessFactory.AuthData().Authenticate(username, password);
            if (result)
            {
                var token = new Token();
                token.Username = username;
                token.CreatedAt = DateTime.Now;
                token.TKey = Guid.NewGuid().ToString().Substring(1, 10);
                globalUsername= token.Username;

                var ret = DataAccessFactory.TokenData().Create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);

                    if (IsDoctor(token.TKey) && (token.Username == DataAccessFactory.MatchDoctorData().Match(username).Username))
                    {
                        return mapper.Map<TokenDTO>(ret);
                    }

                    else if (IsPatient(token.TKey))
                    {
                        var result1 = DataAccessFactory.MatchPatientData().Match(username);
                        if (token.Username == result1.Username)
                        {
                            return mapper.Map<TokenDTO>(ret);
                        }
                    }
                    else if (IsPharmacy(token.TKey))
                    {
                        var result1 = DataAccessFactory.MatchPharmacyData().Match(username);
                        if (token.Username == result1.Username)
                        {
                            return mapper.Map<TokenDTO>(ret);
                        }
                    }
                    else if (IsAdmin(token.TKey))
                    {
                        var result1 = DataAccessFactory.MatchAdminData().Match(username);
                        if (token.Username == result1.Username)
                        {
                            return mapper.Map<TokenDTO>(ret);
                        }
                    }
                }
            }
            return null;
        }

        public static string Check()
        {
            return globalUsername;
        }

        public static bool IsTokenValid(string TKey)
        {
            var existingToken = DataAccessFactory.TokenData().Get(TKey);
            if (existingToken != null && existingToken.DeletedAt == null)
            {
                return true;
            }
            return false;
        }

        public static bool Logout(string TKey)
        {
            var existingToken = DataAccessFactory.TokenData().Get(TKey);
            existingToken.DeletedAt = DateTime.Now;
            if (DataAccessFactory.TokenData().Update(existingToken) != null)
            {
                return true;
            }
            return false;
        }

        public static bool IsDoctor(string TKey)
        {
            var existingToken = DataAccessFactory.TokenData().Get(TKey);
            if (IsTokenValid(TKey) && existingToken.User.Role.Equals("Doctor") 
                && existingToken.Username == DataAccessFactory.UserData().Get(globalUsername).Username)
            {
                return true;
            }
            return false;
        }

        public static bool IsAdmin(string TKey)
        {
            var existingToken = DataAccessFactory.TokenData().Get(TKey);
            if (IsTokenValid(TKey) && existingToken.User.Role.Equals("Admin"))
            {
                return true;
            }
            return false;
        }

        public static bool IsPatient(string TKey)
        {
            var existingToken = DataAccessFactory.TokenData().Get(TKey);
            if (IsTokenValid(TKey) && existingToken.User.Role.Equals("Patient"))
            {
                return true;
            }
            return false;
        }

        public static bool IsPharmacy(string TKey)
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
