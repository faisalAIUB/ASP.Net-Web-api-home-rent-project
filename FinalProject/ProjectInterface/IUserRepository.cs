﻿using ProjectEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInterface
{
    public interface IUserRepository:IRepository<User>
    {
         int LogIn(string Email, string Password);
    }
}
