using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TSvsGTD_Avalonia.Models.AltaTS
{
    public partial class AltaTS4DbContext : DbContext
    {
        public AltaTS4DbContext()
        {
        }

        public AltaTS4DbContext(DbContextOptions<AltaTS4DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DocInSklad> DocInSklads { get; set; } = null!;
        public virtual DbSet<DocInSkladSub> DocInSkladSubs { get; set; } = null!;
        public virtual DbSet<DocOutSklad> DocOutSklads { get; set; } = null!;
        public virtual DbSet<DocOutSkladSub> DocOutSkladSubs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=srv-sql-01;user=dbadmin;password=nhbnjgjkz;database=AltaTS4Db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocInSklad>(entity =>
            {
                entity.HasKey(e => e.UniqueIndexField);

                entity.ToTable("DOC_IN_SKLAD");

                entity.HasIndex(e => e.Guid, "DOC_IN_SKLAD_GUID");

                entity.HasIndex(e => e.GuidDt, "DOC_IN_SKLAD_GUID_DT");

                entity.HasIndex(e => e.Id, "DOC_IN_SKLAD_ID")
                    .IsUnique();

                entity.Property(e => e.Akt)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AKT");

                entity.Property(e => e.CarType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("car_type");

                entity.Property(e => e.Carcountry)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("carcountry");

                entity.Property(e => e.Carname)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("carname");

                entity.Property(e => e.Comment)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Contract)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("contract");

                entity.Property(e => e.DateChk)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_CHK");

                entity.Property(e => e.DateDoc)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_DOC");

                entity.Property(e => e.Docregime)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("DOCREGIME");

                entity.Property(e => e.Dol)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DOL");

                entity.Property(e => e.DolName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DOL_NAME");

                entity.Property(e => e.FG313)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("f_g31_3");

                entity.Property(e => e.G35).HasColumnType("decimal(17, 6)");

                entity.Property(e => e.G38).HasColumnType("decimal(17, 6)");

                entity.Property(e => e.G42).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.G46).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Goods)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("GOODS");

                entity.Property(e => e.GtdDate)
                    .HasColumnType("datetime")
                    .HasColumnName("gtd_date");

                entity.Property(e => e.GtdVpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("gtd_vpdate");

                entity.Property(e => e.Guid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("guid");

                entity.Property(e => e.GuidDt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("guid_dt");

                entity.Property(e => e.Id)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Idinv)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("IDINV");

                entity.Property(e => e.Invoice)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("INVOICE");

                entity.Property(e => e.Lic)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LIC");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Ncar)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("NCAR");

                entity.Property(e => e.Nid).HasColumnName("nid");

                entity.Property(e => e.Npost)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NPOST");

                entity.Property(e => e.NumDoc)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NUM_DOC");

                entity.Property(e => e.Owner).HasColumnName("OWNER");

                entity.Property(e => e.Place)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PLACE");

                entity.Property(e => e.Postdate)
                    .HasColumnType("datetime")
                    .HasColumnName("postdate");

                entity.Property(e => e.Posted).HasColumnName("POSTED");

                entity.Property(e => e.Snd).HasColumnName("SND");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.TamSt)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tam_st");

                entity.Property(e => e.TimeIn)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TIME_IN");

                entity.Property(e => e.TovKol).HasColumnName("TOV_KOL");

                entity.Property(e => e.TovStat)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("TOV_STAT");

                entity.Property(e => e.TypeDoc)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_DOC");

                entity.Property(e => e.UserId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<DocInSkladSub>(entity =>
            {
                entity.HasKey(e => e.UniqueIndexField);

                entity.ToTable("DOC_IN_SKLAD_SUB");

                entity.HasIndex(e => e.KeyId, "DOC_IN_SKLAD_SUB_KEY_ID")
                    .IsUnique();

                entity.HasIndex(e => e.MainId, "DOC_IN_SKLAD_SUB_MAIN_ID");

                entity.Property(e => e.Country)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.Curr)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("curr");

                entity.Property(e => e.DateChk)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_CHK");

                entity.Property(e => e.DateChkDt)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_CHK_DT");

                entity.Property(e => e.ExpDate)
                    .HasColumnType("datetime")
                    .HasColumnName("exp_date");

                entity.Property(e => e.FG313)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("f_g31_3");

                entity.Property(e => e.G31)
                    .HasMaxLength(1250)
                    .IsUnicode(false);

                entity.Property(e => e.G312).HasColumnName("G31_2");

                entity.Property(e => e.G313)
                    .HasColumnType("decimal(17, 3)")
                    .HasColumnName("G31_3");

                entity.Property(e => e.G313a)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("G31_3a");

                entity.Property(e => e.G33In)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("G33_IN");

                entity.Property(e => e.G35).HasColumnType("decimal(17, 3)");

                entity.Property(e => e.G38).HasColumnType("decimal(17, 6)");

                entity.Property(e => e.G41a)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("G41A");

                entity.Property(e => e.G41aDt)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("G41A_DT");

                entity.Property(e => e.G42).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.G46).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Info)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("info");

                entity.Property(e => e.Invoice)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("invoice");

                entity.Property(e => e.KeyId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("key_id");

                entity.Property(e => e.MainId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("main_id");

                entity.Property(e => e.Operation)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("OPERATION");

                entity.Property(e => e.Place)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PLACE");

                entity.Property(e => e.PosId).HasColumnName("pos_id");

                entity.Property(e => e.Sender).HasColumnName("sender");

                entity.Property(e => e.Series)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("series");
            });

            modelBuilder.Entity<DocOutSklad>(entity =>
            {
                entity.HasKey(e => e.UniqueIndexField);

                entity.ToTable("DOC_OUT_SKLAD");

                entity.HasIndex(e => e.Guid, "DOC_OUT_SKLAD_GUID");

                entity.HasIndex(e => e.GuidDt, "DOC_OUT_SKLAD_GUID_DT");

                entity.HasIndex(e => e.Id, "DOC_OUT_SKLAD_ID")
                    .IsUnique();

                entity.HasIndex(e => e.Idord, "DOC_OUT_SKLAD_IDORD");

                entity.HasIndex(e => e.IdDoc, "DOC_OUT_SKLAD_ID_DOC");

                entity.Property(e => e.Akt)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AKT");

                entity.Property(e => e.Comment)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT");

                entity.Property(e => e.DateDoc)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_DOC");

                entity.Property(e => e.Docregime)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("DOCREGIME");

                entity.Property(e => e.Dol)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DOL");

                entity.Property(e => e.DolName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DOL_NAME");

                entity.Property(e => e.FFinish)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("f_finish");

                entity.Property(e => e.Formular)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FORMULAR");

                entity.Property(e => e.G35).HasColumnType("decimal(17, 3)");

                entity.Property(e => e.G46).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.GtdVpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("gtd_vpdate");

                entity.Property(e => e.Guid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("guid");

                entity.Property(e => e.GuidDt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("guid_dt");

                entity.Property(e => e.Id)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.IdDoc)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ID_DOC");

                entity.Property(e => e.Idord)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("idord");

                entity.Property(e => e.Idout)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("IDOUT");

                entity.Property(e => e.Lic)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LIC");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Ncar)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("NCAR");

                entity.Property(e => e.Nid).HasColumnName("nid");

                entity.Property(e => e.Npost)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NPOST");

                entity.Property(e => e.NumDoc)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NUM_DOC");

                entity.Property(e => e.Ordnum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ordnum");

                entity.Property(e => e.Owner).HasColumnName("OWNER");

                entity.Property(e => e.Postdate)
                    .HasColumnType("datetime")
                    .HasColumnName("postdate");

                entity.Property(e => e.Posted).HasColumnName("POSTED");

                entity.Property(e => e.TamSt)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tam_st");

                entity.Property(e => e.TimeOut)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TIME_OUT");

                entity.Property(e => e.TovKol).HasColumnName("TOV_KOL");

                entity.Property(e => e.TypeDoc)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_DOC");

                entity.Property(e => e.UserId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<DocOutSkladSub>(entity =>
            {
                entity.HasKey(e => e.UniqueIndexField);

                entity.ToTable("DOC_OUT_SKLAD_SUB");

                entity.HasIndex(e => e.IdDoc, "DOC_OUT_SKLAD_SUB_ID_DOC");

                entity.HasIndex(e => e.KeyId, "DOC_OUT_SKLAD_SUB_KEY_ID");

                entity.HasIndex(e => e.KeyId2, "DOC_OUT_SKLAD_SUB_KEY_ID2");

                entity.HasIndex(e => e.MainId, "DOC_OUT_SKLAD_SUB_MAIN_ID");

                entity.HasIndex(e => e.NumDoc, "DOC_OUT_SKLAD_SUB_NUM_DOC");

                entity.Property(e => e.Country)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.Curr)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("curr");

                entity.Property(e => e.ExpDate)
                    .HasColumnType("datetime")
                    .HasColumnName("exp_date");

                entity.Property(e => e.FFinish)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("f_finish");

                entity.Property(e => e.Formular)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FORMULAR");

                entity.Property(e => e.G31)
                    .HasMaxLength(1250)
                    .IsUnicode(false);

                entity.Property(e => e.G312).HasColumnName("G31_2");

                entity.Property(e => e.G312Move).HasColumnName("G31_2_MOVE");

                entity.Property(e => e.G313)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("G31_3");

                entity.Property(e => e.G313Move)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("G31_3_MOVE");

                entity.Property(e => e.G313a)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("G31_3a");

                entity.Property(e => e.G31Out)
                    .HasMaxLength(1250)
                    .IsUnicode(false)
                    .HasColumnName("G31_OUT");

                entity.Property(e => e.G32Out).HasColumnName("G32_OUT");

                entity.Property(e => e.G33In)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("G33_IN");

                entity.Property(e => e.G33Out)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("G33_OUT");

                entity.Property(e => e.G35).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.G35Move)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("G35_MOVE");

                entity.Property(e => e.G38Move)
                    .HasColumnType("decimal(17, 6)")
                    .HasColumnName("G38_MOVE");

                entity.Property(e => e.G41a)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("G41A");

                entity.Property(e => e.G42).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.G42Move).HasColumnName("g42_MOVE");

                entity.Property(e => e.G46).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.G46Move)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("G46_MOVE");

                entity.Property(e => e.IdDoc)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ID_DOC");

                entity.Property(e => e.Info)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("info");

                entity.Property(e => e.KeyId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("key_id");

                entity.Property(e => e.KeyId2)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("key_id2");

                entity.Property(e => e.MainId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("main_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.NumDoc)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NUM_DOC");

                entity.Property(e => e.Sender).HasColumnName("sender");

                entity.Property(e => e.Series)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("series");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
