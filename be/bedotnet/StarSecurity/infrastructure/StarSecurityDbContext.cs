using domain.Common.Abstractions;
using domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure
{
	public class StarSecurityDbContext : DbContext
	{
		public StarSecurityDbContext(DbContextOptions<StarSecurityDbContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(StarSecurityDbContext).Assembly);

			modelBuilder.Entity<Account>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Email).IsRequired();
				entity.HasIndex(e => e.Email).IsUnique();
				entity.Property(e => e.PasswordHash).IsRequired();
				entity.HasOne(e => e.Employee)
					.WithMany()
					.HasForeignKey(e => e.EmployeeId)
					.IsRequired();
			});

			modelBuilder.Entity<Branch>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).IsRequired();
				entity.Property(e => e.Region).IsRequired();
				entity.Property(e => e.ContactDetail).IsRequired();
				entity.HasMany(e => e.Employee)
					.WithOne(e => e.Branch)
					.HasForeignKey(e => e.BranchId)
					.IsRequired();
			});

			modelBuilder.Entity<Client>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).IsRequired();
				entity.Property(e => e.Gender).IsRequired();
				entity.Property(e => e.ContactNumber).IsRequired(false);
				entity.Property(e => e.Email).IsRequired();
				entity.HasIndex(e => e.Email).IsUnique();
				entity.HasMany(e => e.Offers)
					.WithOne(o => o.Client)
					.HasForeignKey(o => o.ClientId)
					.IsRequired(false);
			});

			modelBuilder.Entity<Employee>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).IsRequired();
				entity.Property(e => e.Gender).IsRequired();
				entity.Property(e => e.ContactNumber).IsRequired(false);
				entity.Property(e => e.Email).IsRequired();
				entity.HasIndex(e => e.Email).IsUnique();
				entity.Property(e => e.EmployeeCode).IsRequired();
				entity.HasIndex(e => e.EmployeeCode).IsUnique();
				entity.Property(e => e.EducationalQualification).IsRequired();
				entity.Property(e => e.Role).IsRequired();
				entity.Property(e => e.Grade).IsRequired();
				entity.Property(e => e.ProvideService).IsRequired();
				entity.HasOne(e => e.Branch)
					.WithMany(b => b.Employee)
					.HasForeignKey(e => e.BranchId)
					.IsRequired();
				entity.HasMany(e => e.Offers)
					.WithOne(o => o.Employee)
					.HasForeignKey(o => o.EmployeeId)
					.IsRequired();
			});

			modelBuilder.Entity<Offer>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.TotalPayment).IsRequired();
				entity.Property(e => e.StartDate).IsRequired();
				entity.Property(e => e.EndDate).IsRequired();
				entity.Property(e => e.ProvideService).IsRequired();
			});
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			foreach (var entry in ChangeTracker.Entries<Entity>())
			{
				entry.Entity.Update();
				//Haha, no set method to do this
				/*if (entry.State == EntityState.Added)
				{
					entry.Entity.CreateDate = DateTime.UtcNow;
				}*/

			}
			return base.SaveChangesAsync(cancellationToken);
		}

		public DbSet<Account> Accounts { get; set; }
		public DbSet<Branch> Branches { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Offer> Offers { get; set; }

	}
}
