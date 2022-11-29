using Microsoft.EntityFrameworkCore;
using SplitVeryWise.Domain.Entities;

namespace SplitVeryWise.Infrastructure;

public class SplitVeryWiseContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseLine> ExpenseLines { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Group> Groups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=SplitVeryWise;Trusted_Connection=True;MultipleActiveResultSets=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(user =>
        {
            user.HasKey(user => user.Id);

            user.Property(user => user.Name)
                .HasMaxLength(12);

            user.Property(user => user.Password)
                .HasMaxLength(20);
        });

        modelBuilder.Entity<Group>(group =>
        {
            group.HasKey(group => group.Id);

            group.Property(group => group.Name)
                .HasMaxLength(20);
        });

        modelBuilder.Entity<Expense>(exp =>
        {
            exp.HasKey(exp => exp.Id);

            exp.Property(exp => exp.Description)
                .HasMaxLength(80);

            /*exp.HasMany(exp => exp.Lines)
                .WithOne(line => line.Expense)
                .OnDelete(DeleteBehavior.Restrict);*/ // TODO: Cascade?! Multiple cascade paths problem
            // TODO: Add HasForeignKey()s

            exp.HasOne(exp => exp.User)
                .WithMany(user => user.Expenses)
                .OnDelete(DeleteBehavior.Restrict);

            exp.HasOne(exp => exp.Group)
                .WithMany(group => group.Expenses)
                .OnDelete(DeleteBehavior.Restrict);

            // Multiple Cascade Paths
        });

        modelBuilder.Entity<ExpenseLine>(line =>
        {
            line.HasKey(line => line.Id);

            line.Property(line => line.Amount)
                .HasPrecision(3); // TODO: Check second argument

            line.HasOne(line => line.Expense)
                .WithMany(exp => exp.Lines)
                .OnDelete(DeleteBehavior.Restrict);

            line.HasOne(line => line.User)
                .WithMany(user => user.ExpenseLines)
                .OnDelete(DeleteBehavior.Restrict);

            // Multiple Cascade Paths
        });

        modelBuilder.Entity<Payment>(pmt =>
        {
            pmt.HasOne(pmt => pmt.Sender)
                .WithMany(user => user.PaymentsAsSender)
                .OnDelete(DeleteBehavior.Restrict);

            pmt.HasOne(pmt => pmt.Recipient)
                .WithMany(pmt => pmt.PaymentsAsRecipient)
                .OnDelete(DeleteBehavior.Restrict);

            pmt.HasOne(pmt => pmt.Group)
                .WithMany(group => group.Payments);
        });
    }
}