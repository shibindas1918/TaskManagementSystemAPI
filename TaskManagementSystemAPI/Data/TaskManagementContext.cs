﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskManagementSystemAPI.Models;

namespace TaskManagementSystemAPI.Data
{
    // Entity core Dbset implementation 
    public class TaskManagementContext : DbContext
    {
        public TaskManagementContext(DbContextOptions<TaskManagementContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
    }

}
