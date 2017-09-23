using Microsoft.EntityFrameworkCore;
using MusicListDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicListDAL.Context
{
    class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options =
            new DbContextOptionsBuilder<InMemoryContext>()
            .UseInMemoryDatabase("TheDB")
            .Options;
        //Options That we want in Memory
        public InMemoryContext() : base()
        {

        }
        public DbSet<Music> Musics { get; set; }
    }
}
