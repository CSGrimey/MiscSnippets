using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MiscSnippets.Code.Encryption {
    public class TripleDES {
        public const string _encryptedFilePrefix = "encrypted_";

        public void Encrypt(string inputFileName, string outputFileName) {
            byte[] key = Encoding.ASCII.GetBytes(ConfigurationSettings.AppSettings["filesEncryptionKey"]);
            byte[] initialisationVector = Encoding.ASCII.GetBytes(ConfigurationSettings.AppSettings["filesInitialisationVector"]);

            Encrypt(inputFileName, outputFileName, key, initialisationVector);
        }

        public void Encrypt(Stream inputStream, string outputFileName) {
            FileStream outputFileStream = new FileStream(outputFileName, FileMode.OpenOrCreate, FileAccess.Write);

            outputFileStream.SetLength(0);

            byte[] key = Encoding.ASCII.GetBytes(ConfigurationSettings.AppSettings["filesEncryptionKey"]);
            byte[] initialisationVector = Encoding.ASCII.GetBytes(ConfigurationSettings.AppSettings["filesInitialisationVector"]);

            Transform(inputStream, outputFileStream, key, initialisationVector, new TripleDESCryptoServiceProvider().CreateEncryptor);
        }

        public void Encrypt(string inputFileName, string outputFileName, byte[] key, byte[] initialisationVector) {
            FileStream inputFileStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read);
            FileStream outputFileStream = new FileStream(outputFileName, FileMode.OpenOrCreate, FileAccess.Write);

            outputFileStream.SetLength(0);

            Transform(inputFileStream, outputFileStream, key, initialisationVector, new TripleDESCryptoServiceProvider().CreateEncryptor);
        }

        private void Transform(Stream inputFileStream, Stream outputFileStream, byte[] key, byte[] initialisationVector,
            Func<byte[], byte[], ICryptoTransform> transformerCreationFunc) {
            byte[] immediateEncryptionStorage = new byte[100];

            int numberOfBytesToWriteAtATime = 0;
            long totalBytesWritten = 0;

            long inputFileSize = inputFileStream.Length;
            const int offset = 0;

            TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider();

            ICryptoTransform transformer = transformerCreationFunc(key, initialisationVector);

            using (var encStream = new CryptoStream(outputFileStream, transformer, CryptoStreamMode.Write)) {
                while (totalBytesWritten < inputFileSize) {
                    numberOfBytesToWriteAtATime = inputFileStream.Read(immediateEncryptionStorage, offset, count: 100);

                    encStream.Write(immediateEncryptionStorage, offset, numberOfBytesToWriteAtATime);

                    totalBytesWritten = totalBytesWritten + numberOfBytesToWriteAtATime;
                }
            }
        }

        public void Decrypt(string inputFileName, string outputFileName) {
            byte[] key = Encoding.ASCII.GetBytes(ConfigurationSettings.AppSettings["filesEncryptionKey"]);
            byte[] initialisationVector = Encoding.ASCII.GetBytes(ConfigurationSettings.AppSettings["filesInitialisationVector"]);

            Decrypt(inputFileName, outputFileName, key, initialisationVector);
        }

        public void Decrypt(string inputFileName, string outputFileName, byte[] key, byte[] initialisationVector) {
            FileStream inputFileStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read);
            FileStream outputFileStream = new FileStream(outputFileName, FileMode.OpenOrCreate, FileAccess.Write);

            outputFileStream.SetLength(0);

            Transform(inputFileStream, outputFileStream, key, initialisationVector, new TripleDESCryptoServiceProvider().CreateDecryptor);
        }
    }
}
