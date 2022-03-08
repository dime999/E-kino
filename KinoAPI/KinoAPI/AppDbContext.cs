
using KinoAPI.Entiteti;
using KinoAPI.Entities;
using KinoAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;


namespace KinoAPI
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Zanr>().HasData(
            //   new Zanr { id = 1, name = "Horor" },
            //     new Zanr { id = 2, name = "Akcija" },
            //       new Zanr { id = 3, name = "Animirani" },
            //         new Zanr { id = 3, name = "Drama" },
            //           new Zanr { id = 3, name = "Krimi" },
            //             new Zanr { id = 3, name = "Sci-Fi" },
            //               new Zanr { id = 3, name = "Komedija" },
            //                 new Zanr { id = 3, name = "Domaći" },
            //                   new Zanr { id = 3, name = "Historijski" },
            //                     new Zanr { id = 3, name = "Dokumentarni" },
            //                       new Zanr { id = 3, name = "Tinejdžerski film" },
            //                         new Zanr { id = 3, name = "Romantika" },
            //                           new Zanr { id = 3, name = "Avantura" }


            //   );

            //modelBuilder.Entity<KinoProjekcija>().HasData(
            //   new KinoProjekcija { id = 1, dan = "Ponedeljak", termin = "12:00" },
            //    new KinoProjekcija { id = 2, dan = "Ponedeljak", termin = "17:00" },
            //     new KinoProjekcija { id = 3, dan = "Ponedeljak", termin = "20:00" },
            //      new KinoProjekcija { id = 4, dan = "Ponedeljak", termin = "22:00" },

            //       new KinoProjekcija { id = 5, dan = "Utorak", termin = "12:00" },
            //        new KinoProjekcija { id = 6, dan = "Utorak", termin = "17:00" },
            //         new KinoProjekcija { id = 7, dan = "Utorak", termin = "20:00" },
            //          new KinoProjekcija { id = 8, dan = "Utorak", termin = "22:00" },

            //           new KinoProjekcija { id = 10, dan = "Srijeda", termin = "12:00" },
            //            new KinoProjekcija { id = 11, dan = "Srijeda", termin = "17:00" },
            //             new KinoProjekcija { id = 12, dan = "Srijeda", termin = "20:00" },
            //              new KinoProjekcija { id = 13, dan = "Srijeda", termin = "22:00" },

            //              new KinoProjekcija { id = 14, dan = "Četvrtak", termin = "12:00" },
            //               new KinoProjekcija { id = 15, dan = "Četvrtak", termin = "17:00" },
            //                new KinoProjekcija { id = 16, dan = "Četvrtak", termin = "20:00" },
            //                 new KinoProjekcija { id = 17, dan = "Četvrtak", termin = "22:00" },

            //                  new KinoProjekcija { id = 18, dan = "Petak", termin = "12:00" },
            //                   new KinoProjekcija { id = 19, dan = "Petak", termin = "17:00" },
            //                    new KinoProjekcija { id = 20, dan = "Petak", termin = "20:00" },
            //                     new KinoProjekcija { id = 21, dan = "Petak", termin = "22:00" },

            //                      new KinoProjekcija { id = 22, dan = "Subota", termin = "12:00" },
            //                       new KinoProjekcija { id = 23, dan = "Subota", termin = "17:00" },
            //                        new KinoProjekcija { id = 24, dan = "Subota", termin = "20:00" },
            //                         new KinoProjekcija { id = 25, dan = "Subota", termin = "22:00" },


            //                            new KinoProjekcija { id = 27, dan = "Nedelja", termin = "12:00" },
            //                             new KinoProjekcija { id = 28, dan = "Nedelja", termin = "17:00" },
            //                              new KinoProjekcija { id = 29, dan = "Nedelja", termin = "20:00" },
            //                               new KinoProjekcija { id = 30, dan = "Nedelja", termin = "22:00" }








            //   );


            modelBuilder.Entity<FilmZanr>().HasKey(x => new { x.FilmId, x.ZanrId });
            modelBuilder.Entity<FilmKino>().HasKey(x => new { x.FilmId, x.KinoId });
            modelBuilder.Entity<FilmGlumci>().HasKey(x => new { x.FilmId, x.GlumacId });
            modelBuilder.Entity<FilmKinoProjekcija>().HasKey(x => new { x.FilmId, x.KinoProjekcijaId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Zanr> Zanrovi { get; set; }
        public DbSet<Glumac> Glumci { get; set; }
        public DbSet<Kino> Kina { get; set; }
        public DbSet<Film> Filmovi { get; set; }
        public DbSet<KinoProjekcija> KinoProjekcije { get; set; }
        public DbSet<FilmZanr> FilmZanrovi { get; set; }
        public DbSet<FilmKino> FilmKina { get; set; }
        public DbSet<FilmGlumci> FilmGlumci { get; set; }
        public DbSet<FilmKinoProjekcija> FilmKinoProjekcija { get; set; }
        public DbSet<Artikal> Artikli { get; set; }
        public DbSet<Event> Eventi { get; set; }






    }
}
