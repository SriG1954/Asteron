using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppCoreV1.ABLEModels;

public partial class AblearchivalContext : DbContext
{
    public AblearchivalContext()
    {
    }

    public AblearchivalContext(DbContextOptions<AblearchivalContext> options)
        : base(options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
