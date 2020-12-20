using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2S.Test.Models;

namespace T2S.Test.Data
{
    public class ConteinerContext : DbContext
    {
        public ConteinerContext(DbContextOptions<ConteinerContext> options) : base(options)
        {

        }
        public DbSet<Conteiner> Conteiner { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }
        public DbSet<ConteinerMovimentacao> ConteinerMovimentacao { get; set; }
    }
}
