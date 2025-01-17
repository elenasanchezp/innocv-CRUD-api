﻿using innocv_crud.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace innocv_crud.Api.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("InnocvDbContext") { }

        public DbSet<User> Users { get; set; }
    }
}