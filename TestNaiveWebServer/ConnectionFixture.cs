using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NaiveWebServer;
using FluentAssertions;

namespace TestNaiveWebServer
{
    public class ConnectionFixture
    {
        public Connection connection; 

        public ConnectionFixture()
        {
            connection = new Connection(new ServerConfiguration());
        }
        [Fact]
        public void trytostartlistening()
        {
            var result = connection.TryStartListening();

            result.Should().BeTrue();
        }

        [Fact]
        public void trytostoplitening()
        {
            var result = connection.TryStopListening();
            result.Should().BeTrue();
        }
    }
}
