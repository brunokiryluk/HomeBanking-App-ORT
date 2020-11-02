using System;
using System.Collections.Generic;
using System.Text;
using MVCHomeBanking.Models;
using MVCHomeBanking.Models.MovementClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCHomeBanking.Context
{
    public class HomeBankingContext : DbContext
    {

        public HomeBankingContext(DbContextOptions<HomeBankingContext> options) : base(options)
        {
        }

        public DbSet<Bank> banks { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Client> users { get; set; }
        //public DbSet<Movement> movements { get; set; }
        public DbSet<Deposit> deposits { get; set; }
        public DbSet<Extract> extracts { get; set; }
        public DbSet<Transfer> transfers { get; set; }


    }
}
