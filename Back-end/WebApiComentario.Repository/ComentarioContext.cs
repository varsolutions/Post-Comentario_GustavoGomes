using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiComentario.Repository.model;

namespace WebApiComentario.Repository
{
    public class ComentarioContext : DbContext
    {
        public ComentarioContext(DbContextOptions<ComentarioContext> options) : base (options){ }

        public DbSet<tabComentarioPost> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabComentarioPost>().ToTable("tabComentarioPost");
        }
    }
}
