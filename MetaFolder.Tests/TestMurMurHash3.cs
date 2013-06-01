using System;
using System.IO;
using System.Linq;
using System.Text;
using MetaFolder.Representations.Hashes;
using Xunit;

namespace MetaFolder.Tests
{
    public class TestMurMurHash3
    {
        [Fact]
        public void VerificationTest()
        {
            Assert.Equal(new byte[] { },
                BitConverter.GetBytes(
                MurMurHash3.Hash(
                    new MemoryStream(
                        new UTF8Encoding()
                            .GetBytes("The quick brown fox jumps over the lazy dog")), 0)));
        }
    }
}
