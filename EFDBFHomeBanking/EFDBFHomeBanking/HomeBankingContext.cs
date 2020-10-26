using System;
using System.Collections.Generic;
using System.Text;
using EFDBFHomeBanking.Models;
using EFDBFHomeBanking.Models.MovementClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFDBFHomeBanking
{
    public class HomeBankingContext : DbContext
    {
        public DbSet<Bank> banks { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Client> users { get; set; }
        //public DbSet<Movement> movements { get; set; }
        public DbSet<Deposit> deposits { get; set; }
        public DbSet<Extract> extracts { get; set; }
        public DbSet<Transfer> transfers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=HOMEBANKING_SCF;Trusted_Connection=True;");
        }
    }
}
