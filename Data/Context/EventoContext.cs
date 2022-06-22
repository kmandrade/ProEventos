using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class EventoContext : DbContext
    {
        public EventoContext(DbContextOptions<EventoContext> options) : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Evento>()
                .HasKey(e => e.IdEvento);
            modelBuilder.Entity<Evento>()

                .HasData(new Evento
                {
                    IdEvento = 1,
                    Local = "casa",
                    DataEvento= new DateTime(2022, 06, 21, 16, 59, 59),
                    Tema = "Tema",
                    QtdPessoas = 1,
                    Lote = "Lote",
                    ImgURL = "img",
                    Situation = Situation.Active


                });
                
                
                
                

        }
    }
}
