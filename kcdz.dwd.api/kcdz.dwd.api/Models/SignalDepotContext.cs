using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace kcdz.dwd.api.Models
{
    public partial class SignalDepotContext : DbContext
    {
        public SignalDepotContext()
        {
        }

        public SignalDepotContext(DbContextOptions<SignalDepotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Drawing> Drawing { get; set; }
        public virtual DbSet<EquipmentLedger> EquipmentLedger { get; set; }
        public virtual DbSet<EquipmentSemaphore> EquipmentSemaphore { get; set; }
        public virtual DbSet<EquipmentSwitchMachine> EquipmentSwitchMachine { get; set; }
        public virtual DbSet<EquipmentTapeChecker> EquipmentTapeChecker { get; set; }
        public virtual DbSet<EquipmentTurnout> EquipmentTurnout { get; set; }
        public virtual DbSet<EquipmentZone> EquipmentZone { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Drawing>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DrawingName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DrawingUrl)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EquipmentLedger>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BelongOrgan).HasMaxLength(50);

                entity.Property(e => e.BelongStation).HasMaxLength(50);

                entity.Property(e => e.CommissioningDate).HasMaxLength(50);

                entity.Property(e => e.DeviceClassify).HasMaxLength(50);

                entity.Property(e => e.DeviceCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeviceName).HasMaxLength(50);

                entity.Property(e => e.DeviceStatus).HasMaxLength(50);

                entity.Property(e => e.DeviceType).HasMaxLength(50);

                entity.Property(e => e.Manufacturer).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(50);

                entity.Property(e => e.ViewPhoto).HasMaxLength(50);
            });

            modelBuilder.Entity<EquipmentSemaphore>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AdjacentLimit).HasMaxLength(50);

                entity.Property(e => e.BelongStation).HasMaxLength(50);

                entity.Property(e => e.DeviceName).HasMaxLength(50);

                entity.Property(e => e.EquipmentModel).HasMaxLength(50);

                entity.Property(e => e.InstitutionalType).HasMaxLength(50);

                entity.Property(e => e.LensGroupType).HasMaxLength(50);

                entity.Property(e => e.LineLimit).HasMaxLength(50);

                entity.Property(e => e.NumberIndicators).HasMaxLength(50);
            });

            modelBuilder.Entity<EquipmentSwitchMachine>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BelongStation).HasMaxLength(50);

                entity.Property(e => e.DeviceName).HasMaxLength(50);

                entity.Property(e => e.OnThatTime).HasMaxLength(50);

                entity.Property(e => e.SwitchMachineType).HasMaxLength(50);

                entity.Property(e => e.Vender).HasMaxLength(50);

                entity.Property(e => e.WayInstall).HasMaxLength(50);
            });

            modelBuilder.Entity<EquipmentTapeChecker>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BelongStation).HasMaxLength(50);

                entity.Property(e => e.DeviceName).HasMaxLength(50);

                entity.Property(e => e.OnThatTime).HasMaxLength(50);

                entity.Property(e => e.TapeCheckerType).HasMaxLength(50);

                entity.Property(e => e.Vender).HasMaxLength(50);
            });

            modelBuilder.Entity<EquipmentTurnout>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BelongStation).HasMaxLength(50);

                entity.Property(e => e.DeviceName).HasMaxLength(50);

                entity.Property(e => e.GapSupervision).HasMaxLength(50);

                entity.Property(e => e.InterlockType).HasMaxLength(50);

                entity.Property(e => e.MainLine).HasMaxLength(10);

                entity.Property(e => e.NumberSwitchMachine).HasMaxLength(50);

                entity.Property(e => e.SettingType).HasMaxLength(50);

                entity.Property(e => e.SnowMelting).HasMaxLength(50);

                entity.Property(e => e.SwitchType).HasMaxLength(50);

                entity.Property(e => e.TapeChecker).HasMaxLength(50);
            });

            modelBuilder.Entity<EquipmentZone>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BelongStation).HasMaxLength(50);

                entity.Property(e => e.Coding).HasMaxLength(50);

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.System).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.ZoneLength).HasMaxLength(50);
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StationName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
