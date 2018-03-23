using ContactManager.Mappers;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Tests.Unit.Framework
{
    public class TestBase
    {
        private static volatile bool _mapperConfigured;

        #region Private Members
        private IConfigurationRoot _configuration { get; set; }
        #endregion Private Members

        public TestBase()
        {
            _configuration = Substitute.For<IConfigurationRoot>();

            ConfigMapper();
        }

        private static void ConfigMapper()
        {
            if (!_mapperConfigured)
            {
                new DtoToDomainMapper().ConfigMapper();
                new DomainToEntityMapper().ConfigMapper();
                _mapperConfigured = true;
            }
        }
    }
}
