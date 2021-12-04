using GzipCompressor;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GzipCompressor_Test
{
    public class GzipCompressor_Test
    {
        [Fact]
        public void CompressAndDecompressString_Test()
        {
            // Arange
            var student = new Student { Id = 1, Age = 16, Name = "Frank" };
            var originalString = JsonConvert.SerializeObject(student);
            //Act
            var compressedString = GzipCompressHelper.CompressString(originalString);
            var decompressedString = GzipCompressHelper.DecompressString(compressedString);
            //Assert
            decompressedString.ShouldBe(originalString);
        }
        [Fact]
        public void CompressNullOrEmptyString_Test()
        {
            // Arange
            var inputEmptyString = string.Empty;
            try
            {
                //Act
                var compressedString = GzipCompressHelper.CompressString(inputEmptyString);
            }
            catch (Exception ex)
            {
                //Assert
                ex.ShouldBeOfType(typeof(ArgumentNullException));
            }
            // Arange
            string inputNullString = null;
            try
            {
                //Act
                var compressedString = GzipCompressHelper.CompressString(inputNullString);
            }
            catch (Exception ex)
            {
                //Assert
                ex.ShouldBeOfType(typeof(ArgumentNullException));
            }

        }
        [Fact]
        public void CompressAndDecompressStream_Test()
        {
            // Arange
            var student = new Student { Id = 1, Age = 16, Name = "Frank" };
            var originalString = JsonConvert.SerializeObject(student);
            var originalByteArray = Encoding.UTF8.GetBytes(originalString);
            var originalStream = new MemoryStream(originalByteArray);
            //Act
            var compressedStream = GzipCompressHelper.CompressStream(originalStream);
            var decompressedStream = GzipCompressHelper.DecompressStream(compressedStream);
            using (var sr = new StreamReader(decompressedStream))
            {
                var decompressString = sr.ReadToEnd();
                //Assert
                decompressString.ShouldBe(originalString);
            }
        }

        [Fact]
        public async Task CompressAndDecompressStringAsync_Test()
        {
            // Arange
            var student = new Student { Id = 1, Age = 16, Name = "Frank" };
            var originalString = JsonConvert.SerializeObject(student);
            //Act
            var compressedString = await GzipCompressHelper.CompressStringAsync(originalString);
            var decompressedString = await GzipCompressHelper.DecompressStringAsync(compressedString);
            //Assert
            decompressedString.ShouldBe(originalString);
        }
        [Fact]
        public async Task CompressNullOrEmptyStringAsync_Test()
        {
            // Arange
            var inputEmptyString = string.Empty;
            try
            {
                //Act
                var compressedString = await GzipCompressHelper.CompressStringAsync(inputEmptyString);
            }
            catch (Exception ex)
            {
                //Assert
                ex.ShouldBeOfType(typeof(ArgumentNullException));
            }
            // Arange
            string inputNullString = null;
            try
            {
                //Act
                var compressedString = await GzipCompressHelper.CompressStringAsync(inputNullString);
            }
            catch (Exception ex)
            {
                //Assert
                ex.ShouldBeOfType(typeof(ArgumentNullException));
            }

        }
        [Fact]
        public async Task CompressAndDecompressStreamAsync_Test()
        {
            // Arange
            var student = new Student { Id = 1, Age = 16, Name = "Frank" };
            var originalString = JsonConvert.SerializeObject(student);
            var originalByteArray = Encoding.UTF8.GetBytes(originalString);
            var originalStream = new MemoryStream(originalByteArray);
            //Act
            var compressedStream = await GzipCompressHelper.CompressStreamAsync(originalStream);
            var decompressedStream = await GzipCompressHelper.DecompressStreamAsync(compressedStream);
            using (var sr = new StreamReader(decompressedStream))
            {
                var decompressString = sr.ReadToEnd();
                //Assert
                decompressString.ShouldBe(originalString);
            }
        }
        [Fact]
        public void CompressStringLength_Test()
        {
            // Arange
            var student = new Student { Id = 1, Age = 16, Name = "Frank" };
            var originalString = JsonConvert.SerializeObject(student);
            //Act
            var compressedString = GzipCompressHelper.CompressString(originalString).Length;
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(originalString));
            var compressedStream = GzipCompressHelper.CompressStream(stream);

            var compressedStreamString = ByteHelper.GetString(compressedStream.ToArray()).Length;

            //Assert
            compressedString.ShouldBeEquivalentTo(compressedStreamString);
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}