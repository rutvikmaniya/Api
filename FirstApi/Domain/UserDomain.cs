using FirstApi.Models;
using FP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstApi.Domain
{
    public class UserDomain:MainDomain
    {
        public UserDomain()
        {
            this.con();
        }
        public void Post(User user)
        {
            
            this.ExecuteNonQuery($"insert into Users (FirstName,LastName,Password,Country,Gender) values ('{user.FirstName}','{user.LastName}','{user.Password}','{user.Country}','{user.Gender }')");
        }
        public List<User> Get()
        {
            var reader = this.GetReader("select * from Users");
            var user = new List<User>();
            while(reader.Read())
            {
                var users = new User();
                users.UserId = reader.GetInt32(0);
                users.FirstName = reader.GetString(1);
                users.LastName = reader.GetString(2);
                users.Password = reader.GetString(3);
                users.Country = reader.GetString(4);
                user.Add(users);
            }
            return user;
        }
        public List<User> GetBy(int id)
        {
            var reader = this.GetReader($"select * from Users where UserId={id}");
            var user = new List<User>();
            while (reader.Read())
            {
                var users = new User();
                users.UserId = reader.GetInt32(0);
                users.FirstName = reader.GetString(1);
                users.LastName = reader.GetString(2);
                users.Password = reader.GetString(3);
                users.Country = reader.GetString(4);
                users.Gender = reader.GetString(5);
                user.Add(users);
            }
            return user;
        }
        public void Delete(int id)
        {
            this.ExecuteNonQuery($"delete from Users where UserId={id}");
        }
        public void Put(User user,int id)
        {
            this.ExecuteNonQuery($"update Users set FirstName='{user.FirstName}',LastName='{user.LastName}',Password='{user.Password}',Country='{user.Country}' where UserId={id}");
        }
        public void Patch(int id)
        {
            User user = new User();
            this.ExecuteNonQuery($"update Users set FirstName='{user.FirstName}',LastName='{user.LastName}',Password='{user.Password}',Country='{user.Country}' where UserId={id}");
        }
        public void closeconnection()
        {
            this.CloseConnection();  
        }
    }
}