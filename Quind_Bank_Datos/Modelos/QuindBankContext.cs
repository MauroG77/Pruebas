using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Quind_Bank_Domain;

namespace Quind_Bank_Datos.Modelos;

public partial class QuindBankContext : DbContext
{
    public QuindBankContext()
    {
    }

    public QuindBankContext(DbContextOptions<QuindBankContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuenta> Cuentas { get; set; }

    public virtual DbSet<Transaccion> Transacciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Integrated Security=SSPI;Initial Catalog=QUIND_BANK;Data Source=MAURICIOG; Encrypt=False");
    }
        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__CLIENTES__677F38F5EF8C98A9");

            entity.ToTable("CLIENTES");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroIdentificacion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("numero_identificacion");
            entity.Property(e => e.TipoIdentificacion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("tipo_identificacion");
        });

        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.HasKey(e => e.IdCuenta).HasName("PK__CUENTAS__C7E2868597556EA5");

            entity.ToTable("CUENTAS");

            entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.ExentaGmf).HasColumnName("exenta_gmf");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.NumCuenta)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("num_cuenta");
            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("saldo");
            entity.Property(e => e.TipoCuenta)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo_cuenta");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdCliente)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IDCLIENTE");
        });

        modelBuilder.Entity<Transaccion>(entity =>
        {
            entity.HasKey(e => e.IdTransaccion).HasName("PK__TRANSACC__1EDAC0994BF67754");

            entity.ToTable("TRANSACCIONES");

            entity.Property(e => e.IdTransaccion).HasColumnName("id_transaccion");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("monto");
            entity.Property(e => e.NumCuentaDestino)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("num_cuenta_destino");
            entity.Property(e => e.TipoTransaccion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo_transaccion");

            entity.HasOne(d => d.IdCuentaNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IDCUENTA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
