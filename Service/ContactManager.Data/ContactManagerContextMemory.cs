using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Data
{
    public class ContactManagerContextMemory : ContactManagerContextSql
    {
        #region Private Members 

        #endregion Private Members

        #region Constructor
        public ContactManagerContextMemory(IConfigurationRoot configuration)
            : base(configuration)
        {

        }
        #endregion Constructor

        #region Public Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods
    }
}
