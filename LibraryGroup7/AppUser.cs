using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup7
{
    public class AppUser : IdentityUser 
    {
        public int AppUserId { get; set; }
        public string Fullname { get; set; }
        public string UserType { get; set; }

        public AppUser(string fullname, string email, string phone, string password)
        {
            this.Fullname = fullname;
            this.Email = email;
            this.UserName = email;
            this.PhoneNumber = phone;
            PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();
            this.PasswordHash = hasher.HashPassword(this, password);

        }

        public AppUser()
        {

        }

    }

    
}