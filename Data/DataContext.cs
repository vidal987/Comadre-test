using System;
using Microsoft.EntityFrameworkCore;
using teste_comadre.Models;

namespace teste_comadre.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        { }

        public DataContext() {}  
        
        public DbSet<Account> Account {get; set;}
        public DbSet<Transaction> Transaction { get; set; }
    }
}