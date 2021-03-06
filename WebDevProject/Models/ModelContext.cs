﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDevProject.Models
{
    public class ModelContext : IdentityDbContext<ApplicationUser>

    {
        private IConfigurationRoot _config;

        public ModelContext(IConfigurationRoot config, DbContextOptions options) :base(options)
        {
            _config = config;
        }

        public DbSet<Index> Index { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<IndexReferenceList> IndexReferenceList { get; set; }
        public DbSet<ModuleReferenceList> ModuleReferenceList { get; set; }
        public DbSet<TopicReferenceList> TopicReferenceList { get; set; }
        public DbSet<QuestionReferenceList> QuestionReferenceList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString: _config["ConnectionStrings:ModelContextConnection"]);
        }
    }
}
