#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class backendContext : DbContext
    {
        public backendContext (DbContextOptions<backendContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Societe> Societes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Demande> Demandes { get; set; }
    }
}
