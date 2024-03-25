using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace StarSecurityAPI.Data
{
	public class StarSecurityAPIContext : DbContext
	{
		public StarSecurityAPIContext(DbContextOptions options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Account>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Email).IsRequired();
				entity.HasIndex(e => e.Email).IsUnique();
				entity.Property(e => e.PasswordHash).IsRequired();
				//relationship
				/*entity.HasOne(a => a.Employee)
					.WithMany()
					.HasForeignKey(e => e.EmployeeId)
					.IsRequired();*/
			});
			modelBuilder.Entity<Branch>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).IsRequired();
				entity.Property(e => e.Region)
					.HasConversion<string>().IsRequired();
				entity.Property(e => e.ContactDetail).IsRequired();
			});
			modelBuilder.Entity<Client>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).IsRequired();
				entity.Property(e => e.Gender).IsRequired();
				entity.Property(e => e.ContactNumber).IsRequired(false);
				entity.Property(e => e.Email).IsRequired();
				entity.HasIndex(e => e.Email).IsUnique();
				entity.Property(e => e.CurrentOfferId).IsRequired(false);
				//relationship
				/*entity.HasMany(c => c.Offers)
					.WithOne(o => o.Client)
					.IsRequired(false);*/
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
				entity.Property(e => e.CurrentOfferId).IsRequired(false);
				//relationship
				/*entity.HasOne(e => e.Branch)
					.WithMany(b => b.Employee)
					.HasForeignKey(e => e.BranchId)
					.IsRequired();
				entity.HasMany(e => e.Offers)
					.WithOne(o => o.Employee)
					.IsRequired(false);*/
			});

			modelBuilder.Entity<Offer>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.TotalPayment).IsRequired();
				entity.Property(e => e.StartDate).IsRequired();
				entity.Property(e => e.EndDate).IsRequired();
				entity.Property(e => e.ProvideService).IsRequired();
				//relationship
				/*entity.HasOne(e => e.Employee)
					.WithMany(o => o.Offers)
					.HasForeignKey(e => e.EmployeeId)
					.IsRequired();
				entity.HasOne(e => e.Client)
					.WithMany(o => o.Offers)
					.HasForeignKey(e => e.ClientId)
					.IsRequired();*/
			});
		}
		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			foreach (var entry in ChangeTracker.Entries<Entity>())
			{
				entry.Entity.UpdatedDate = DateTime.UtcNow;

				/*if (entry.State == EntityState.Added)
				{
					entry.Entity.Id = new Guid();
					entry.Entity.CreateDate = DateTime.UtcNow;
				}*/

			}
			return base.SaveChangesAsync(cancellationToken);
		}
		public DbSet<Account> Account { get; set; }
		public DbSet<Branch> Branch { get; set; }
		public DbSet<Client> Client { get; set; }
		public DbSet<Employee> Employee { get; set; }
		public DbSet<Offer> Offer { get; set; }
	}
}
