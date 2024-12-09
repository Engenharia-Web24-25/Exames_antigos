using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EW_NOR_2024.Models;

namespace EW_NOR_2024.Data
{
    public class EW_NOR_2024Context : DbContext
    {
        public EW_NOR_2024Context (DbContextOptions<EW_NOR_2024Context> options)
            : base(options)
        {
        }

        public DbSet<EW_NOR_2024.Models.RegistoUtilizador> RegistoUtilizador { get; set; } = default!;
    }
}
