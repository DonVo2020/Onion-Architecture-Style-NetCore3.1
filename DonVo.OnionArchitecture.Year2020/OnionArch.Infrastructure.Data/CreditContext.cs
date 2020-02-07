using Microsoft.EntityFrameworkCore;
using OnionArch.Domain.Entities;

namespace OnionArch.Infrastructure.Data
{
    public partial class CreditContext : DbContext
    {
        public CreditContext()
        {
        }

        public CreditContext(DbContextOptions<CreditContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BasicMember> BasicMember { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Charge> Charge { get; set; }
        public virtual DbSet<ChargeWide> ChargeWide { get; set; }
        public virtual DbSet<CorpMember> CorpMember { get; set; }
        public virtual DbSet<Corporation> Corporation { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Member2> Member2 { get; set; }
        public virtual DbSet<Overdue> Overdue { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentWide> PaymentWide { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Statement> Statement { get; set; }
        public virtual DbSet<StatementWide> StatementWide { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<Test2> Test2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasicMember>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("basic_member");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ExprDt)
                    .HasColumnName("expr_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FirstName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LastName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MailCode)
                    .IsRequired()
                    .HasColumnName("mail_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MemberCode)
                    .IsRequired()
                    .HasColumnName("member_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MemberNo).HasColumnName("member_no");

                entity.Property(e => e.Middleinitial)
                    .HasColumnName("middleinitial")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNo)
                    .HasColumnName("phone_no")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegionNo).HasColumnName("region_no");

                entity.Property(e => e.StateProv)
                    .IsRequired()
                    .HasColumnName("state_prov")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryNo)
                    .HasName("category_ident");

                entity.ToTable("category");

                entity.Property(e => e.CategoryNo).HasColumnName("category_no");

                entity.Property(e => e.CategoryCode)
                    .IsRequired()
                    .HasColumnName("category_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('  ')");

                entity.Property(e => e.CategoryDesc)
                    .IsRequired()
                    .HasColumnName("category_desc")
                    .HasMaxLength(31)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Charge>(entity =>
            {
                entity.HasKey(e => e.ChargeNo)
                    .HasName("ChargePK");

                entity.ToTable("charge");

                entity.HasIndex(e => e.CategoryNo)
                    .HasName("charge_category_link");

                entity.HasIndex(e => e.ProviderNo)
                    .HasName("charge_provider_link");

                entity.HasIndex(e => e.StatementNo)
                    .HasName("charge_statement_link");

                entity.Property(e => e.ChargeNo).HasColumnName("charge_no");

                entity.Property(e => e.CategoryNo).HasColumnName("category_no");

                entity.Property(e => e.ChargeAmt)
                    .HasColumnName("charge_amt")
                    .HasColumnType("money");

                entity.Property(e => e.ChargeCode)
                    .IsRequired()
                    .HasColumnName("charge_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('  ')");

                entity.Property(e => e.ChargeDt)
                    .HasColumnName("charge_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.MemberNo).HasColumnName("member_no");

                entity.Property(e => e.ProviderNo).HasColumnName("provider_no");

                entity.Property(e => e.StatementNo)
                    .HasColumnName("statement_no")
                    .HasDefaultValueSql("(0)");

                entity.HasOne(d => d.CategoryNoNavigation)
                    .WithMany(p => p.Charge)
                    .HasForeignKey(d => d.CategoryNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("charge_category_link");

                entity.HasOne(d => d.MemberNoNavigation)
                    .WithMany(p => p.Charge)
                    .HasForeignKey(d => d.MemberNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("charge_member_link");

                entity.HasOne(d => d.ProviderNoNavigation)
                    .WithMany(p => p.Charge)
                    .HasForeignKey(d => d.ProviderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("charge_provider_link");
            });

            modelBuilder.Entity<ChargeWide>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("charge_wide");

                entity.Property(e => e.CategoryDesc)
                    .IsRequired()
                    .HasColumnName("category_desc")
                    .HasMaxLength(31)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryNo).HasColumnName("category_no");

                entity.Property(e => e.ChargeAmt)
                    .HasColumnName("charge_amt")
                    .HasColumnType("money");

                entity.Property(e => e.ChargeCode)
                    .IsRequired()
                    .HasColumnName("charge_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ChargeDt)
                    .HasColumnName("charge_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ChargeNo).HasColumnName("charge_no");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FirstName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LastName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MemberNo).HasColumnName("member_no");

                entity.Property(e => e.ProviderName)
                    .IsRequired()
                    .HasColumnName("provider_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderNo).HasColumnName("provider_no");

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasColumnName("region_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RegionNo).HasColumnName("region_no");
            });

            modelBuilder.Entity<CorpMember>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("corp_member");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CorpCode)
                    .IsRequired()
                    .HasColumnName("corp_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CorpName)
                    .IsRequired()
                    .HasColumnName("corp_name")
                    .HasMaxLength(31)
                    .IsUnicode(false);

                entity.Property(e => e.CorpNo).HasColumnName("corp_no");

                entity.Property(e => e.ExprDt)
                    .HasColumnName("expr_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FirstName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LastName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MailCode)
                    .IsRequired()
                    .HasColumnName("mail_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MemberNo).HasColumnName("member_no");

                entity.Property(e => e.Middleinitial)
                    .HasColumnName("middleinitial")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasColumnName("phone_no")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegionNo).HasColumnName("region_no");

                entity.Property(e => e.StateProv)
                    .IsRequired()
                    .HasColumnName("state_prov")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Corporation>(entity =>
            {
                entity.HasKey(e => e.CorpNo)
                    .HasName("corporation_ident");

                entity.ToTable("corporation");

                entity.HasIndex(e => e.RegionNo)
                    .HasName("corporation_region_link");

                entity.Property(e => e.CorpNo).HasColumnName("corp_no");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CorpCode)
                    .IsRequired()
                    .HasColumnName("corp_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('  ')");

                entity.Property(e => e.CorpName)
                    .IsRequired()
                    .HasColumnName("corp_name")
                    .HasMaxLength(31)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExprDt)
                    .HasColumnName("expr_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.MailCode)
                    .IsRequired()
                    .HasColumnName("mail_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasColumnName("phone_no")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegionNo).HasColumnName("region_no");

                entity.Property(e => e.StateProv)
                    .IsRequired()
                    .HasColumnName("state_prov")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.RegionNoNavigation)
                    .WithMany(p => p.Corporation)
                    .HasForeignKey(d => d.RegionNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("corporation_region_link");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.MemberNo)
                    .HasName("member_ident");

                entity.ToTable("member");

                entity.HasIndex(e => e.CorpNo)
                    .HasName("member_corporation_link");

                entity.HasIndex(e => e.RegionNo)
                    .HasName("member_region_link");

                entity.Property(e => e.MemberNo).HasColumnName("member_no");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CorpNo).HasColumnName("corp_no");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CurrBalance)
                    .HasColumnName("curr_balance")
                    .HasColumnType("money")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ExprDt)
                    .HasColumnName("expr_dt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(year,1,getdate()))");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FirstName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IssueDt)
                    .HasColumnName("issue_dt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LastName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MailCode)
                    .IsRequired()
                    .HasColumnName("mail_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MemberCode)
                    .IsRequired()
                    .HasColumnName("member_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('  ')");

                entity.Property(e => e.Middleinitial)
                    .HasColumnName("middleinitial")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNo)
                    .HasColumnName("phone_no")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Photograph)
                    .HasColumnName("photograph")
                    .HasColumnType("image");

                entity.Property(e => e.PrevBalance)
                    .HasColumnName("prev_balance")
                    .HasColumnType("money")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RegionNo).HasColumnName("region_no");

                entity.Property(e => e.StateProv)
                    .IsRequired()
                    .HasColumnName("state_prov")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.CorpNoNavigation)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.CorpNo)
                    .HasConstraintName("member_corporation_link");

                entity.HasOne(d => d.RegionNoNavigation)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.RegionNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("member_region_link");
            });

            modelBuilder.Entity<Member2>(entity =>
            {
                entity.HasKey(e => e.MemberNo)
                    .HasName("member2PK")
                    .IsClustered(false);

                entity.ToTable("member2");

                entity.HasIndex(e => e.CorpNo)
                    .HasName("member2CorpFK");

                entity.HasIndex(e => e.RegionNo)
                    .HasName("member2RegionFK");

                entity.HasIndex(e => new { e.LastName, e.FirstName, e.Middleinitial })
                    .HasName("member2Cl")
                    .IsClustered();

                entity.Property(e => e.MemberNo)
                    .HasColumnName("member_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CorpNo).HasColumnName("corp_no");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CurrBalance)
                    .HasColumnName("curr_balance")
                    .HasColumnType("money");

                entity.Property(e => e.ExprDt)
                    .HasColumnName("expr_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FirstName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IssueDt)
                    .HasColumnName("issue_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LastName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MailCode)
                    .IsRequired()
                    .HasColumnName("mail_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MemberCode)
                    .IsRequired()
                    .HasColumnName("member_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Middleinitial)
                    .HasColumnName("middleinitial")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNo)
                    .HasColumnName("phone_no")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Photograph)
                    .HasColumnName("photograph")
                    .HasColumnType("image");

                entity.Property(e => e.PrevBalance)
                    .HasColumnName("prev_balance")
                    .HasColumnType("money");

                entity.Property(e => e.RegionNo).HasColumnName("region_no");

                entity.Property(e => e.StateProv)
                    .IsRequired()
                    .HasColumnName("state_prov")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Overdue>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("overdue");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DueDt)
                    .HasColumnName("due_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExprDt)
                    .HasColumnName("expr_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FirstName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LastName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MailCode)
                    .IsRequired()
                    .HasColumnName("mail_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MemberCode)
                    .IsRequired()
                    .HasColumnName("member_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MemberNo).HasColumnName("member_no");

                entity.Property(e => e.Middleinitial)
                    .HasColumnName("middleinitial")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNo)
                    .HasColumnName("phone_no")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasColumnName("region_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RegionNo).HasColumnName("region_no");

                entity.Property(e => e.StateProv)
                    .IsRequired()
                    .HasColumnName("state_prov")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StatementAmt)
                    .HasColumnName("statement_amt")
                    .HasColumnType("money");

                entity.Property(e => e.StatementCode)
                    .IsRequired()
                    .HasColumnName("statement_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StatementDt)
                    .HasColumnName("statement_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatementNo).HasColumnName("statement_no");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentNo)
                    .HasName("payment_ident")
                    .IsClustered(false);

                entity.ToTable("payment");

                entity.HasIndex(e => e.MemberNo)
                    .HasName("payment_member_link");

                entity.Property(e => e.PaymentNo).HasColumnName("payment_no");

                entity.Property(e => e.MemberNo).HasColumnName("member_no");

                entity.Property(e => e.PaymentAmt)
                    .HasColumnName("payment_amt")
                    .HasColumnType("money");

                entity.Property(e => e.PaymentCode)
                    .IsRequired()
                    .HasColumnName("payment_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('  ')");

                entity.Property(e => e.PaymentDt)
                    .HasColumnName("payment_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatementNo)
                    .HasColumnName("statement_no")
                    .HasDefaultValueSql("(0)");

                entity.HasOne(d => d.MemberNoNavigation)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.MemberNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("payment_member_link");
            });

            modelBuilder.Entity<PaymentWide>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("payment_wide");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ExprDt)
                    .HasColumnName("expr_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FirstName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LastName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MailCode)
                    .IsRequired()
                    .HasColumnName("mail_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MemberCode)
                    .IsRequired()
                    .HasColumnName("member_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MemberNo).HasColumnName("member_no");

                entity.Property(e => e.Middleinitial)
                    .HasColumnName("middleinitial")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaymentAmt)
                    .HasColumnName("payment_amt")
                    .HasColumnType("money");

                entity.Property(e => e.PaymentCode)
                    .IsRequired()
                    .HasColumnName("payment_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaymentDt)
                    .HasColumnName("payment_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentNo).HasColumnName("payment_no");

                entity.Property(e => e.PhoneNo)
                    .HasColumnName("phone_no")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasColumnName("region_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RegionNo).HasColumnName("region_no");

                entity.Property(e => e.StateProv)
                    .IsRequired()
                    .HasColumnName("state_prov")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.ProviderNo)
                    .HasName("provider_ident");

                entity.ToTable("provider");

                entity.HasIndex(e => e.RegionNo)
                    .HasName("provider_region_link");

                entity.Property(e => e.ProviderNo).HasColumnName("provider_no");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExprDt)
                    .HasColumnName("expr_dt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(year,1,getdate()))");

                entity.Property(e => e.IssueDt)
                    .HasColumnName("issue_dt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MailCode)
                    .IsRequired()
                    .HasColumnName("mail_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasColumnName("phone_no")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProviderCode)
                    .IsRequired()
                    .HasColumnName("provider_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('  ')");

                entity.Property(e => e.ProviderName)
                    .IsRequired()
                    .HasColumnName("provider_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RegionNo).HasColumnName("region_no");

                entity.Property(e => e.StateProv)
                    .IsRequired()
                    .HasColumnName("state_prov")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.RegionNoNavigation)
                    .WithMany(p => p.Provider)
                    .HasForeignKey(d => d.RegionNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("provider_region_link");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionNo)
                    .HasName("region_ident");

                entity.ToTable("region");

                entity.Property(e => e.RegionNo).HasColumnName("region_no");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MailCode)
                    .IsRequired()
                    .HasColumnName("mail_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasColumnName("phone_no")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegionCode)
                    .IsRequired()
                    .HasColumnName("region_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('  ')");

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasColumnName("region_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.StateProv)
                    .IsRequired()
                    .HasColumnName("state_prov")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Statement>(entity =>
            {
                entity.HasKey(e => e.StatementNo)
                    .HasName("statement_ident");

                entity.ToTable("statement");

                entity.HasIndex(e => e.MemberNo)
                    .HasName("statement_member_link");

                entity.Property(e => e.StatementNo).HasColumnName("statement_no");

                entity.Property(e => e.DueDt)
                    .HasColumnName("due_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.MemberNo).HasColumnName("member_no");

                entity.Property(e => e.StatementAmt)
                    .HasColumnName("statement_amt")
                    .HasColumnType("money");

                entity.Property(e => e.StatementCode)
                    .IsRequired()
                    .HasColumnName("statement_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('  ')");

                entity.Property(e => e.StatementDt)
                    .HasColumnName("statement_dt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.MemberNoNavigation)
                    .WithMany(p => p.Statement)
                    .HasForeignKey(d => d.MemberNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("statement_member_link");
            });

            modelBuilder.Entity<StatementWide>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("statement_wide");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DueDt)
                    .HasColumnName("due_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExprDt)
                    .HasColumnName("expr_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FirstName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LastName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MailCode)
                    .IsRequired()
                    .HasColumnName("mail_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MemberCode)
                    .IsRequired()
                    .HasColumnName("member_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MemberNo).HasColumnName("member_no");

                entity.Property(e => e.Middleinitial)
                    .HasColumnName("middleinitial")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNo)
                    .HasColumnName("phone_no")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasColumnName("region_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RegionNo).HasColumnName("region_no");

                entity.Property(e => e.StateProv)
                    .IsRequired()
                    .HasColumnName("state_prov")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StatementAmt)
                    .HasColumnName("statement_amt")
                    .HasColumnType("money");

                entity.Property(e => e.StatementCode)
                    .IsRequired()
                    .HasColumnName("statement_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StatementDt)
                    .HasColumnName("statement_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatementNo).HasColumnName("statement_no");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.StatusCode)
                    .HasName("status_ident");

                entity.ToTable("status");

                entity.Property(e => e.StatusCode)
                    .HasColumnName("status_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StatusDesc)
                    .IsRequired()
                    .HasColumnName("status_desc")
                    .HasMaxLength(31)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("test");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FirstName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LastName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MemberNo)
                    .HasColumnName("member_no")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Test2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("test2");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LastName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MemberNo)
                    .HasColumnName("member_no")
                    .ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
