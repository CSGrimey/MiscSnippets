using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MiscSnippets.Code.Encryption {
    public class TripleDES {
        private byte[] GetKey() => Encoding.ASCII.GetBytes(ConfigurationSettings.AppSettings["filesEncryptionKey"]);

        private byte[] GetInitialisationVector() => Encoding.ASCII.GetBytes(ConfigurationSettings.AppSettings["filesInitialisationVector"]);

        public void Encrypt(string inputFileName, string outputFileName) {
            Encrypt(inputFileName, outputFileName, GetKey(), GetInitialisationVector());
        }

        public void Encrypt(Stream inputStream, string outputFileName) {
            var outputFileStream = new FileStream(outputFileName, FileMode.OpenOrCreate, FileAccess.Write);

            outputFileStream.SetLength(0);

            Transform(inputStream, outputFileStream, new TripleDESCryptoServiceProvider().CreateEncryptor(GetKey(), GetInitialisationVector()));
        }

        private void Encrypt(string inputFileName, string outputFileName, byte[] key, byte[] initialisationVector) {
            var inputFileStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read);
            var outputFileStream = new FileStream(outputFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            outputFileStream.SetLength(0);

            Transform(inputFileStream, outputFileStream, new TripleDESCryptoServiceProvider().CreateEncryptor(key, initialisationVector));
        }

        private void Transform(Stream inputFileStream, Stream outputFileStream, ICryptoTransform cryptoTransformer) {
            byte[] immediateEncryptionStorage = new byte[1000];
            int numberOfBytesToWriteAtATime = 0;
            long totalBytesWritten = 0;
            const int offset = 0;

            using (var cryptoStream = new CryptoStream(outputFileStream, cryptoTransformer, CryptoStreamMode.Write)) {
                while (totalBytesWritten < inputFileStream.Length) {
                    numberOfBytesToWriteAtATime = inputFileStream.Read(immediateEncryptionStorage, offset, count: 100);

                    cryptoStream.Write(immediateEncryptionStorage, offset, numberOfBytesToWriteAtATime);

                    totalBytesWritten += numberOfBytesToWriteAtATime;
                }
            }
        }

        public void Decrypt(string inputFileName, string outputFileName) {
            Decrypt(inputFileName, outputFileName, GetKey(), GetInitialisationVector());
        }

        private void Decrypt(string inputFileName, string outputFileName, byte[] key, byte[] initialisationVector) {
            var inputFileStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read);
            var outputFileStream = new FileStream(outputFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            outputFileStream.SetLength(0);

            Transform(inputFileStream, outputFileStream, new TripleDESCryptoServiceProvider().CreateDecryptor(key, initialisationVector));
        }
    }
}
