using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EW_NOR_2023.Models;

namespace EW_NOR_2023.Data
{
    public class EW_NOR_2023Context : DbContext
    {
        public EW_NOR_2023Context (DbContextOptions<EW_NOR_2023Context> options)
            : base(options)
        {
        }

        public DbSet<EW_NOR_2023.Models.Proprietario> Proprietarios { get; set; } = default!;

        public DbSet<EW_NOR_2023.Models.Veiculo> Veiculos { get; set; } = default!;
    }
}
