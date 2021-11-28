﻿using Xunit;

namespace Meadow.Modbus.Unit.Tests
{
    public class TcpMessageGenerationTests
    {
        [Fact]
        public void TestFunction3Generation()
        {
            var client = new ModbusTcpClientShim();

            client.ReadHoldingRegisters(7, 11, 13);

            // valid output from a known-good RTU sender
            var expected = new byte[] { 0x00, 0x07, 0x00, 0x00, 0x00, 0x06, 0x07, 0x03, 0x00, 0x0b, 0x00, 0x0d };

            Assert.Equal(expected, client.LastGeneratedMessage);
        }

        [Fact]
        public void TestFunction6Generation()
        {
            var client = new ModbusTcpClientShim();

            client.WriteHoldingRegister(1, 7, 42);

            // valid output from a known-good RTU sender
            var expected = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x06, 0x00, 0x07, 0x00, 0x2a };

            Assert.Equal(expected, client.LastGeneratedMessage);
        }
    }
}