using System;
using katio.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace katio_net.Data;

public class katioContext: DbContext
{
    public katioContext(DbContextOptions<katioContext> options) : base(options)
    {}
    public DbSet<Book> Books { get; set;} = null;
    public DbSet<Author> Author { get; set;} = null;
    public DbSet<User> User { get; set;} = null;
    public DbSet<AudioBooks> AudioBooks { get; set;} = null;
    public DbSet<Narrator> Narrator { get; set;} = null;
    public DbSet<Genres> Genres { get; set;} = null;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        if (builder ==null)
        {
            return;
        }

        builder.Entity<Book>().ToTable("Books").HasKey(k =>k.Id);
        builder.Entity<Author>().ToTable("Author").HasKey(k =>k.Id);
        builder.Entity<User>().ToTable("User").HasKey(k =>k.Id);
        builder.Entity<AudioBooks>().ToTable("AudioBooks").HasKey(k =>k.Id);
        builder.Entity<Narrator>().ToTable("Narrator").HasKey(k =>k.Id);
        builder.Entity<Genres>().ToTable("Genres").HasKey(k =>k.Id);

        base.OnModelCreating(builder);
    }






}