using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Data
{
    public class ContactManagerContextSql : ContactManagerContext
    {
        #region Private Methods
        #endregion Private Methods

        #region Constructor
        public ContactManagerContextSql(IConfigurationRoot configuration) : base(configuration)
        {

        }
        #endregion Constructor

        #region Public Methods


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["Data:DefaultConnection:ConnectionString"]);
        }
        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods
    }
}
