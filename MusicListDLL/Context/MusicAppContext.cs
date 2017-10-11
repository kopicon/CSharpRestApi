using Microsoft.EntityFrameworkCore;
using List.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace List.Context
{
    class MusicAppContext : DbContext
    {
        static DbContextOptions<MusicAppContext> options =
            new DbContextOptionsBuilder<MusicAppContext>()
            .UseInMemoryDatabase("TheDB")
            .Options;
        //Options That we want in Memory
        public MusicAppContext() : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(ca => new { ca.OrderDate, ca.MusicId });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
