using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProConsulta.Models;

namespace ProConsulta.Data
{
    public class DbInitializer 
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        internal void Seed()
        {
            _modelBuilder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole
                    {
                        Id = "3f2504e0-4f89-41d3-9a0c-0305e82c3301",
                        Name = "Atendente",
                        NormalizedName = "ATENDENTE"
                    },
                    new IdentityRole
                    {
                        Id = "5b5504e0-4f89-41d3-9a0c-0305e82c2020",
                        Name = "Medico",
                        NormalizedName = "MEDICO"
                    }
                );

            var hash = new PasswordHasher<IdentityUser>();

            _modelBuilder.Entity<Atendente>().HasData
                (
                    new Atendente
                    {
                        Id = "a1b2c3d4-5e6f-78g9-h0i1-23456789abcd",
                        UserName = "proconsulta@hotmail.com",
                        NormalizedUserName = "PROCONSULTA@HOTMAIL.COM.BR",
                        Email = "proconsulta@hotmail.com",
                        NormalizedEmail = "PROCONSULTA@HOTMAIL.COM.BR",
                        EmailConfirmed = true,
                        PasswordHash = hash.HashPassword(null, "12345678"),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        PhoneNumber = "11999999999",
                        Nome = "Pro Consulta"
                    }
                );

            _modelBuilder.Entity<IdentityUserRole<string>>().HasData
                (
                    new IdentityUserRole<string>
                    {
                        RoleId = "3f2504e0-4f89-41d3-9a0c-0305e82c3301",
                        UserId = "a1b2c3d4-5e6f-78g9-h0i1-23456789abcd"
                    }
                );

            _modelBuilder.Entity<Especialidade>().HasData
                (
                    new Especialidade { Id = 1, Nome = "Cardiologia", Descricao = "Especialidade médica que cuida do coração e sistema circulatório." },
                    new Especialidade { Id = 2, Nome = "Ortopedia", Descricao = "Especialidade focada no sistema musculoesquelético." },
                    new Especialidade { Id = 3, Nome = "Dermatologia", Descricao = "Estudo e tratamento das doenças da pele." },
                    new Especialidade { Id = 4, Nome = "Pediatria", Descricao = "Cuidado da saúde infantil." },
                    new Especialidade { Id = 5, Nome = "Neurologia", Descricao = "Diagnóstico e tratamento de doenças do sistema nervoso." },
                    new Especialidade { Id = 6, Nome = "Oftalmologia", Descricao = "Tratamento de doenças e distúrbios da visão." },
                    new Especialidade { Id = 7, Nome = "Ginecologia", Descricao = "Saúde do sistema reprodutor feminino." },
                    new Especialidade { Id = 8, Nome = "Endocrinologia", Descricao = "Estudo das glândulas e hormônios do corpo." },
                    new Especialidade { Id = 9, Nome = "Psiquiatria", Descricao = "Diagnóstico e tratamento de transtornos mentais." },
                    new Especialidade { Id = 10, Nome = "Urologia", Descricao = "Tratamento do sistema urinário e reprodutor masculino." }
                );
        }
    }
}
