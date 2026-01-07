using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppCoreV1.ABLEModels;

public partial class AblearchiveContext : DbContext
{
    public AblearchiveContext()
    {
    }

    public AblearchiveContext(DbContextOptions<AblearchiveContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence<decimal>("STIMS_ABLE_CONFIG_ROWS")
            .StartsAt(5721L)
            .HasMin(0L)
            .HasMax(9223372036854775807L);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
