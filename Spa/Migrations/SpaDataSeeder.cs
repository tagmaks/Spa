using Spa.Entities;
using Spa.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spa.Migrations
{
    public class SpaDataSeeder
    {
        ApplicationDbContext _ctx;
        public SpaDataSeeder(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        static string[] customerNames = 
        { 
            "Taiseer,Joudeh,Male,hotmail.com", 
            "Hasan,Ahmad,Male,mymail.com", 
            "Moatasem,Ahmad,Male,outlook.com", 
            "Salma,Tamer,Female,outlook.com", 
            "Ahmad,Radi,Male,gmail.com", 
            "Bill,Gates,Male,yahoo.com", 
            "Shareef,Khaled,Male,gmail.com", 
            "Aram,Naser,Male,gmail.com", 
            "Layla,Ibrahim,Female,mymail.com", 
            "Rema,Oday,Female,hotmail.com",
            "Fikri,Husein,Male,gmail.com",
            "Noura,Ahmad,Female,outlook.com"
        };

        static string[] products =
        {

        };

        public string[] SplitValue(string val)
        {
            return val.Split(',');
        }

        public string RandomString(int size)
        {
            Random _rng = new Random((int)DateTime.Now.Ticks);
            string _char = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] buffer = new char[size];
            for (int i = 0; i < size; i++)
            {
                buffer[i] = _char[_rng.Next(_char.Length)];
            }
            return new string(buffer);
        }
        public void Seed()
        {
            try
            {
                var group = new CustomerGroup()
                {
                    GroupName = "Default",
                    Discount = 0
                };
                _ctx.CustomerGroups.Add(group);

                //foreach (var customerName in customerNames)
                //{
                //    var nameGenderMail = SplitValue(customerName);
                //    var user = new ApplicationUser()
                //    {
                //        FirstName = String.Format("{0}", nameGenderMail[0]),
                //        LastName = String.Format("{1}", nameGenderMail[1]),
                //        RegistrationDate = DateTime.Now,
                //        UserName = String.Format("{0}{1}", nameGenderMail[0], nameGenderMail[1]),
                //        PasswordHash = RandomString(8),
                //        Email = String.Format("{0}.{1}@{2}", nameGenderMail[0], nameGenderMail[1], nameGenderMail[3]),
                //    };
                //    _ctx.Users.Add(user);

                //    var customer = new Customer()
                //    {
                //        SubscribedNews = true,
                //        CustomerGroup = group,
                //        ApplicationUser = user
                //    };
                //}

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                throw ex;
            }
        }
    }
}