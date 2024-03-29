using Ocelot.Configuration;
using Ocelot.Configuration.Creator;
using Ocelot.Configuration.File;
using Shouldly;
using System.Collections.Generic;
using TestStack.BDDfy;
using Xunit;

namespace Ocelot.UnitTests.Configuration
{
    public class DownstreamAddressesCreatorTests
    {
        public DownstreamAddressesCreator _creator;
        private FileReRoute _reRoute;
        private List<DownstreamHostAndPort> _result;

        public DownstreamAddressesCreatorTests()
        {
            _creator = new DownstreamAddressesCreator();
        }

        [Fact]
        public void should_do_nothing()
        {
            var reRoute = new FileReRoute
            {
            };

            var expected = new List<DownstreamHostAndPort>
            {
            };

            this.Given(x => GivenTheFollowingReRoute(reRoute))
                .When(x => WhenICreate())
                .Then(x => TheThenFollowingIsReturned(expected))
                .BDDfy();
        }

        [Fact]
        public void should_create_downstream_addresses_from_old_downstream_path_and_port()
        {
            var reRoute = new FileReRoute
            {
                DownstreamHostAndPorts = new List<FileHostAndPort>
                {
                    new FileHostAndPort
                    {
                        Host = "test",
                        Port = 80
                    }
                },
            };

            var expected = new List<DownstreamHostAndPort>
            {
                new DownstreamHostAndPort("test", 80),
            };

            this.Given(x => GivenTheFollowingReRoute(reRoute))
                .When(x => WhenICreate())
                .Then(x => TheThenFollowingIsReturned(expected))
                .BDDfy();
        }

        [Fact]
        public void should_create_downstream_addresses_from_downstream_host_and_ports()
        {
            var reRoute = new FileReRoute
            {
                DownstreamHostAndPorts = new List<FileHostAndPort>
                {
                    new FileHostAndPort
                    {
                        Host = "test",
                        Port = 80
                    },
                    new FileHostAndPort
                    {
                        Host = "west",
                        Port = 443
                    }
                }
            };

            var expected = new List<DownstreamHostAndPort>
            {
                new DownstreamHostAndPort("test", 80),
                new DownstreamHostAndPort("west", 443)
            };

            this.Given(x => GivenTheFollowingReRoute(reRoute))
                .When(x => WhenICreate())
                .Then(x => TheThenFollowingIsReturned(expected))
                .BDDfy();
        }

        private void GivenTheFollowingReRoute(FileReRoute reRoute)
        {
            _reRoute = reRoute;
        }

        private void WhenICreate()
        {
            _result = _creator.Create(_reRoute);
        }

        private void TheThenFollowingIsReturned(List<DownstreamHostAndPort> expecteds)
        {
            _result.Count.ShouldBe(expecteds.Count);

            for (int i = 0; i < _result.Count; i++)
            {
                var result = _result[i];
                var expected = expecteds[i];

                result.Host.ShouldBe(expected.Host);
                result.Port.ShouldBe(expected.Port);
            }
        }
    }
}
