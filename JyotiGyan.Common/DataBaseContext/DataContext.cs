using JyotiGyan.Common.DataBaseContext.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JyotiGyan.Common.DataBaseContext;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
       
    }
    public DbSet<ZipCode> ZipCodes { get; set; }
    public DbSet<ZipCodeTemp> ZipCodesTemps { get; set; } 
}
