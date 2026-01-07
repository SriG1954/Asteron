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
        => optionsBuilder.UseSqlServer("Server=claimscentral-sql.wlife.com.au;Database=ABLEArchival;User ID=db_admin;Password=90K8mKX23jigVLesL40d;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
