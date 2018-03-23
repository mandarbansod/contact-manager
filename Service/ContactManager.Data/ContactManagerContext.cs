using ContactManager.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManager.Data
{
    public class ContactManagerContext : DbContext, IContactManagerContext
    {
        #region Private Members
        protected IConfigurationRoot _configuration;
        private readonly ILogger _logger;
        #endregion Private Members

        #region Public Members
        public DbSet<Contact> Contacts { get; set; }
        #endregion Public Members

        #region Constructor
        public ContactManagerContext(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }
        #endregion Constructor

        #region Public Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(c => c.ID)
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                entity.Property(c => c.FirstName)
                        .IsRequired()
                        .HasMaxLength(50);

                entity.Property(c => c.LastName)
                        .IsRequired()
                        .HasMaxLength(50);


                entity.Property(c => c.Email)
                        .IsRequired()
                        .HasMaxLength(100);


                entity.Property(c => c.PhoneNumber)
                        .IsRequired()
                        .HasMaxLength(50);

                entity.Property(c => c.IsActive)
                        .IsRequired()
                        .HasDefaultValue(false);

                entity.HasKey(c => c.ID);
            });
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            DateTime now = DateTime.Now;
            IEnumerable<EntityEntry<BaseEntity>> changeset = ChangeTracker.Entries<BaseEntity>();
            foreach (EntityEntry<BaseEntity> entityEntry in changeset)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        entityEntry.Entity.CreatedDate = now;
                        break;
                    case EntityState.Modified:
                        entityEntry.Entity.UpdatedDate = now;
                        break;
                }
            }
            return await base.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await SaveChangesAsync(default(CancellationToken)) > 0;
        }

        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods
    }
}
