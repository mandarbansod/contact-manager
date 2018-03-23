using ContactManager.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManager.Data
{
    public interface IContactManagerContext
    {
        DbSet<Contact> Contacts { get; set; }
        int SaveChanges();

        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<bool> SaveChangesAsync();
    }
}
