using System;
using Bit.Core.Services;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Bit.Core.Test.Services
{
    public class RelayPushRegistrationServiceTests
    {
        private readonly RelayPushRegistrationService _sut;

        private readonly GlobalSettings _globalSettings;
        private readonly ILogger<RelayPushRegistrationService> _logger;

        public RelayPushRegistrationServiceTests()
        {
            _globalSettings = new GlobalSettings();
            _logger = Substitute.For<ILogger<RelayPushRegistrationService>>();

            _sut = new RelayPushRegistrationService(
                _globalSettings,
                _logger
            );
        }

        // Remove this test when we add actual tests. It only proves that
        // we've properly constructed the system under test.
        [Fact(Skip = "Needs additional work")]
        public void ServiceExists()
        {
            Assert.NotNull(_sut);
        }
    }
}
