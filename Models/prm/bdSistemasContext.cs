using System;
using EvaluacionEmpresa.Models.custom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EvaluacionEmpresa.Models.prm
{
    public partial class bdSistemasContext : DbContext
    {
        public bdSistemasContext()
        {
        }

        public bdSistemasContext(DbContextOptions<bdSistemasContext> options)
            : base(options)
        {
        }
        public virtual DbSet<PrmColaborador> PrmColaboradores { get; set; }
        public virtual DbSet<PrmContrato> PrmContratos { get; set; }
        public virtual DbSet<PrmDesempenio> PrmDesempenios { get; set; }
        public virtual DbSet<PrmEmpresa> PrmEmpresas { get; set; }
        public virtual DbSet<PrmEmpresaServicio> PrmEmpresaServicios { get; set; }
        public virtual DbSet<PrmEmpresaTipoInformacion> PrmEmpresaTipoInformaciones { get; set; }
        public virtual DbSet<PrmEvaluacion> PrmEvaluaciones { get; set; }
        public virtual DbSet<PrmEvaluacionEmpresa> PrmEvaluacionEmpresas { get; set; }
        public virtual DbSet<PrmGiro> PrmGiros { get; set; }
        public virtual DbSet<PrmResponsable> PrmResponsables { get; set; }
        public virtual DbSet<PrmServicio> PrmServicios { get; set; }
        public virtual DbSet<PrmTipoInformacion> PrmTipoInformaciones { get; set; }
        public virtual DbSet<PrvwProveedoresActivo> PrvwProveedoresActivos { get; set; }
        public virtual DbSet<PrvwProveedoresInactivo> PrvwProveedoresInactivos { get; set; }
     
        public DbSet<prmEmpresaResponsableActiva> prmEmpresaResponsableActivas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=devbdw64b.uag.mx,1433;Database=bdSistemas;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<PrmColaborador>(entity =>
            {
                entity.HasKey(e => e.IdColaborador)
                    .HasName("pkprmColaborador");

                entity.ToTable("prmColaborador");

                entity.Property(e => e.Activo).HasDefaultValueSql("((0))");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Extension)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActivo).HasColumnType("datetime");

                entity.Property(e => e.FechaInActivo).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Foto).HasColumnType("image");

                entity.Property(e => e.IpActivo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IpInactiva)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Puesto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioActivo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioInActivo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.PrmColaboradors)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkEmpresa");
            });

            modelBuilder.Entity<PrmContrato>(entity =>
            {
                entity.HasKey(e => e.IdContrato)
                    .HasName("PK__prmContr__8569F05A94A51BFF");

                entity.ToTable("prmContrato");

                entity.Property(e => e.Cconfidencialidad)
                    .HasColumnName("CConfidencialidad")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Comentarios).IsUnicode(false);

                entity.Property(e => e.Contrato).HasDefaultValueSql("((0))");

                entity.Property(e => e.Incidentes).HasDefaultValueSql("((0))");

                entity.Property(e => e.NivelesServicio).HasDefaultValueSql("((0))");

                entity.Property(e => e.PoliticasNormas).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdEvaluacionEmpresaNavigation)
                    .WithMany(p => p.PrmContratos)
                    .HasForeignKey(d => d.IdEvaluacionEmpresa)
                    .HasConstraintName("FK__prmContra__IdEva__24334AAC");
            });

            modelBuilder.Entity<PrmDesempenio>(entity =>
            {
                entity.HasKey(e => e.IdDesempenio)
                    .HasName("PK__prmDesem__16DF966FC00635C5");

                entity.ToTable("prmDesempenio");

                entity.Property(e => e.Comentarios).IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdEvaluacionEmpresaNavigation)
                    .WithMany(p => p.PrmDesempenios)
                    .HasForeignKey(d => d.IdEvaluacionEmpresa)
                    .HasConstraintName("FK__prmDesemp__IdEva__2BD46C74");
            });

            modelBuilder.Entity<PrmEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("pkprmEmpresa");

                entity.ToTable("prmEmpresa");

                entity.Property(e => e.Activa).HasDefaultValueSql("((0))");

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActiva).HasColumnType("datetime");

                entity.Property(e => e.FechaInActiva).HasColumnType("datetime");

                entity.Property(e => e.IpActiva)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IpInactiva)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Municipio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rfc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RFC");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.Property(e => e.UsuarioActiva)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioInActiva)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGiroNavigation)
                    .WithMany(p => p.PrmEmpresas)
                    .HasForeignKey(d => d.IdGiro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkprmGiro");
            });

            modelBuilder.Entity<PrmEmpresaServicio>(entity =>
            {
                entity.HasKey(e => e.IdEmpSvr)
                    .HasName("pkprmEmpresaServicio");

                entity.ToTable("prmEmpresaServicio");

                entity.HasIndex(e => new { e.IdEmpresa, e.IdServicio }, "ucprmEmpresaServicio")
                    .IsUnique();

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.PrmEmpresaServicios)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("fkprmEmpresaServicio");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.PrmEmpresaServicios)
                    .HasForeignKey(d => d.IdServicio)
                    .HasConstraintName("fkServicioEmpresa");
            });

            modelBuilder.Entity<PrmEmpresaTipoInformacion>(entity =>
            {
                entity.HasKey(e => e.IdEmpInfo)
                    .HasName("PK__prmEmpre__71E66F02503B127D");

                entity.ToTable("prmEmpresaTipoInformacion");

                entity.Property(e => e.Transfiere).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.PrmEmpresaTipoInformacions)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkIdEmpresa");

                entity.HasOne(d => d.IdTipoInfoNavigation)
                    .WithMany(p => p.PrmEmpresaTipoInformacions)
                    .HasForeignKey(d => d.IdTipoInfo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkIdTipoInfo");
            });

            modelBuilder.Entity<PrmEvaluacion>(entity =>
            {
                entity.HasKey(e => e.IdEvaluacion)
                    .HasName("PK__prmEvalu__A7EA657C2F28115B");

                entity.ToTable("prmEvaluacion");

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.Periodo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrmEvaluacionEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdEvaluacionEmpresa)
                    .HasName("PK__prmEvalu__68257327ABE21D75");

                entity.ToTable("prmEvaluacionEmpresa");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.PrmEvaluacionEmpresas)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__prmEvalua__IdEmp__2062B9C8");

                entity.HasOne(d => d.IdEvaluacionNavigation)
                    .WithMany(p => p.PrmEvaluacionEmpresas)
                    .HasForeignKey(d => d.IdEvaluacion)
                    .HasConstraintName("FK__prmEvalua__IdEva__1F6E958F");

                entity.HasOne(d => d.IdResponsableNavigation)
                    .WithMany(p => p.PrmEvaluacionEmpresas)
                    .HasForeignKey(d => d.IdResponsable)
                    .HasConstraintName("FK__prmEvalua__IdRes__2156DE01");
            });

            modelBuilder.Entity<PrmGiro>(entity =>
            {
                entity.HasKey(e => e.IdGiro)
                    .HasName("pkprmGiro");

                entity.ToTable("prmGiro");

                entity.Property(e => e.Giro)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrmResponsable>(entity =>
            {
                entity.HasKey(e => e.IdResponsable)
                    .HasName("PK__prmRespo__CCF9B550EC7FA17B");

                entity.ToTable("prmResponsable");

                entity.Property(e => e.IdUag).HasColumnName("IdUAG");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.PrmResponsables)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__prmRespon__IdEmp__1AA9E072");
            });

            modelBuilder.Entity<PrmServicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("pkprmServicio");

                entity.ToTable("prmServicio");

                entity.Property(e => e.Servicio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrmTipoInformacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoInfo)
                    .HasName("PK__prmTipoI__D5FFBC30DC3C2BAA");

                entity.ToTable("prmTipoInformacion");

                entity.Property(e => e.TipoInformacion)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrvwProveedoresActivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("prvwProveedoresActivos");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoEmpresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Dependencia)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extension)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Idarea).HasColumnName("idarea");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Puesto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rhvdesasipre)
                    .IsRequired()
                    .HasMaxLength(140)
                    .IsUnicode(false)
                    .HasColumnName("RHVDESASIPRE");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoEmpresa)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrvwProveedoresInactivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("prvwProveedoresInactivos");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoEmpresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Dependencia)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extension)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Idarea).HasColumnName("idarea");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Puesto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rhvdesasipre)
                    .IsRequired()
                    .HasMaxLength(140)
                    .IsUnicode(false)
                    .HasColumnName("RHVDESASIPRE");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoEmpresa)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
