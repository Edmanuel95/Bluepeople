using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace api.grupokmm.flujos.Helpers.Data.Models
{
    public partial class SistemaFlujosContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public SistemaFlujosContext()
        {
            
        }

        public SistemaFlujosContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SistemaFlujosContext(DbContextOptions<SistemaFlujosContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Bitacora> Bitacoras { get; set; }
        public virtual DbSet<Clasificacione> Clasificaciones { get; set; }
        public virtual DbSet<CobradoReal> CobradoReals { get; set; }
        public virtual DbSet<Concepto> Conceptos { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<DetalleProyeccion> DetalleProyeccions { get; set; }
        public virtual DbSet<DiaSemana> DiaSemanas { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Institucione> Instituciones { get; set; }
        public virtual DbSet<LineasCredito> LineasCreditos { get; set; }
        public virtual DbSet<Proyeccion> Proyeccions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolesAsignado> RolesAsignados { get; set; }
        public virtual DbSet<Semana> Semanas { get; set; }
        public virtual DbSet<Sesione> Sesiones { get; set; }
        public virtual DbSet<TipoProyeccion> TipoProyeccions { get; set; }
        public virtual DbSet<TiposLinea> TiposLineas { get; set; }
        public virtual DbSet<TiposMovimientoBitacora> TiposMovimientoBitacoras { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<VariacionProyeccion> VariacionProyeccions { get; set; }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=DS002;Database=SistemaFlujos; User Id=sa; Password=Cmc120479.;Trusted_Connection=False;");
                //optionsBuilder.UseSqlServer("Server=tcp:rasecmc.database.windows.net,1433;Initial Catalog=sistemaflujos;Persist Security Info=False;User ID=flujos;Password=Gsm211085.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                //optionsBuilder.UseSqlServer("Server=GVIBA-SRVTRANS\\SQLEXPRESSKMM;Database=SistemaFlujos; User Id=flujos; Password=0#e”+:MTZ%;Trusted_Connection=False;");
                optionsBuilder.UseSqlServer("Server=GVIBA-LCOSISTAS\\SQLEXPRESS;Database=SistemaFlujos;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Bitacora");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.FechaMovimiento).HasColumnType("date");
            });

            modelBuilder.Entity<Clasificacione>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<CobradoReal>(entity =>
            {
                entity.HasKey(e => e.IdCobradoReal);

                entity.ToTable("CobradoReal");

                entity.Property(e => e.FechaCobro).HasColumnType("date");

                entity.Property(e => e.MontoCobradoReal).HasColumnType("money");

                entity.HasOne(d => d.DetalleProyeccion)
                    .WithMany(p => p.CobradoReals)
                    .HasForeignKey(d => d.DetalleProyeccionId)
                    .HasConstraintName("FK_CobradoReal_DetalleProyeccion");
            });

            modelBuilder.Entity<Concepto>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.FechaModificacion).HasColumnType("date");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento);

                entity.Property(e => e.EsActivo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NombreDepartamento)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<DetalleProyeccion>(entity =>
            {
                entity.HasKey(e => e.IdDetalleProyeccion);

                entity.ToTable("DetalleProyeccion");

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.FechaProyeccion).HasColumnType("date");

                entity.Property(e => e.MontoProyectado).HasColumnType("money");

                entity.Property(e => e.MontoReal).HasColumnType("money");

                entity.HasOne(d => d.DiaSemana)
                    .WithMany(p => p.DetalleProyeccions)
                    .HasForeignKey(d => d.DiaSemanaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleProyeccion_DiaSemana");

                entity.HasOne(d => d.Proyeccion)
                    .WithMany(p => p.DetalleProyeccions)
                    .HasForeignKey(d => d.ProyeccionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleProyeccion_Proyeccion");
            });

            modelBuilder.Entity<DiaSemana>(entity =>
            {
                entity.HasKey(e => e.IdDiaSemana);

                entity.ToTable("DiaSemana");

                entity.Property(e => e.Dia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<Institucione>(entity =>
            {
                entity.HasKey(e => e.IdInstitucion);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EsActivo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<LineasCredito>(entity =>
            {
                entity.HasKey(e => e.IdLineaCredito);

                entity.ToTable("LineasCredito");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.EsActivo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaActualizacion).HasColumnType("date");

                entity.Property(e => e.MontoLinea).HasColumnType("money");

                entity.Property(e => e.MontoTransito).HasColumnType("money");

                entity.Property(e => e.Observaciones).HasMaxLength(400);

                entity.Property(e => e.SaldoDisponible).HasColumnType("money");

                entity.Property(e => e.SaldoDispuesto).HasColumnType("money");

                entity.Property(e => e.TasaInteres)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.LineasCreditos)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LineasCredito_Empresas");

                entity.HasOne(d => d.TipoLinea)
                    .WithMany(p => p.LineasCreditos)
                    .HasForeignKey(d => d.TipoLineaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LineasCredito_TiposLinea");
            });

            modelBuilder.Entity<Proyeccion>(entity =>
            {
                entity.HasKey(e => e.IdProyeccion);

                entity.ToTable("Proyeccion");

                entity.Property(e => e.EsActivo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.HasOne(d => d.Semana)
                    .WithMany(p => p.Proyeccions)
                    .HasForeignKey(d => d.SemanaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proyeccion_Semana");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RolesAsignado>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Semana>(entity =>
            {
                entity.HasKey(e => e.IdSemana);

                entity.ToTable("Semana");

                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");
            });

            modelBuilder.Entity<Sesione>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Extra).HasMaxLength(400);

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IP");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TipoProyeccion>(entity =>
            {
                entity.HasKey(e => e.IdTipoProyeccion);

                entity.ToTable("TipoProyeccion");

                entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoID");

                entity.Property(e => e.TipoProyeccion1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TipoProyeccion");
            });

            modelBuilder.Entity<TiposLinea>(entity =>
            {
                entity.HasKey(e => e.IdTipoLinea);

                entity.ToTable("TiposLinea");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.EsActivo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TiposMovimientoBitacora>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TiposMovimientoBitacora");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Seccion)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.EsActivo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaAlta).HasColumnType("date");

                entity.Property(e => e.FechaBaja).HasColumnType("date");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_DetalleProyeccion");

                entity.HasOne(d => d.IdUsuario1)
                    .WithMany()
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Proyeccion");
            });

            modelBuilder.Entity<VariacionProyeccion>(entity =>
            {
                entity.HasKey(e => e.IdVariacionProyeccion);

                entity.ToTable("VariacionProyeccion");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.MontoVariacion).HasColumnType("money");

                entity.HasOne(d => d.DetalleProyeccion)
                    .WithMany(p => p.VariacionProyeccions)
                    .HasForeignKey(d => d.DetalleProyeccionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VariacionProyeccion_DetalleProyeccion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
