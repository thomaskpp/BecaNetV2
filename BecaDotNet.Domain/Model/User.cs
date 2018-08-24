﻿using System;

namespace BecaDotNet.Domain.Model
{
    public class User : IdentifiedEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public int UserTypeId { get; set; }
        public int? SuperiorId { get; set; }
        public UserType UserType { get; set; }

        public User()
        {
            RegisterDate = DateTime.Now;
            UserTypeId = 2;
        }
    }
}
