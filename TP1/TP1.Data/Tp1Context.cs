using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TP1.Domain;

namespace TP1.Data;

public class Tp1Context : DbContext
{
    public Tp1Context(DbContextOptions<Tp1Context> options) : base(options)
    {

    }

    public DbSet<Friend> Friends { get; set; }
}