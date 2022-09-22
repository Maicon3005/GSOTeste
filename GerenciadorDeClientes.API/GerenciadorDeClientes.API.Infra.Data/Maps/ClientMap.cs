using GerenciadorDeClientes.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace GerenciadorDeClientes.API.Infra.Data.Maps
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("client");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder.Property(c => c.Name)
                .HasColumnName("name");

            builder.Property(c => c.Cpf)
                .HasColumnName("cpf");

            builder.Property(c => c.BirthDate)
                .HasColumnName("birth_date");
        }
    }
}
