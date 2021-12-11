using GzipCompressor;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GzipCompressor_Test
{
    public class ByteHelper_Test
    {
        [Fact]
        public void OddLengthByteArrayToString_Test()
        {

            try
            {
                var testString = "abcdefghijklmn";
                var testBytes = Encoding.UTF8.GetBytes(testString);
                byte[] bytes;
                if (testBytes.Length % 2 == 0)
                {
                    bytes = new byte[testBytes.Length-1];
                    for(int i = 0; i< bytes.Length; i++)
                    {
                        bytes[i]=testBytes[i];
                    }
                }
                else
                {
                    bytes = testBytes;
                }
                var resultString = ByteHelper.GetString(bytes);
                resultString.Length.ShouldBeGreaterThan(0);
            }
            catch (Exception ex)
            {
                ex.ShouldBeNull();
            }
        }
    }
}
