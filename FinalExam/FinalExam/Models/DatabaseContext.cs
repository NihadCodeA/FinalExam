﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Models
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
    }
}
