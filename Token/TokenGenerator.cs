﻿using GraphQLApiDemo.Model;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GraphQLApiDemo.Token
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration configuration;
        public string GenerateToken(UserDetailsModel userdetails)
        {
            //1. Create the claims
            var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim(ClaimTypes.Role,$"{userdetails.EmpCode}"),
            }; //payload

            //2. Create ur secret key, and also the Hashing Algorithm (Signing Credentials)
            var secret = "MoinuddinshaikhmainprojectUserDetails";
            var key = Encoding.UTF8.GetBytes(secret);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            //3. Create the token
            var token = new JwtSecurityToken(
                issuer: "authapiMoinuddin",
                audience: "userapi",
                claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddMinutes(30)
                );

            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return JsonConvert.SerializeObject(response);
        }
    }

    public interface ITokenGenerator
    {
        string GenerateToken(UserDetailsModel userdetails);
    }
}
