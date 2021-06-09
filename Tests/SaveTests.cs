using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using NUnit.Framework;
using User;

namespace Tests
{
    public partial class Tests
    {
        [Test]
        public void EmptyInfoToSave()
        {
            Assert.Throws<ArgumentException>(() => new SaveFile("test", new byte[0], new byte[0]));
        }

        [Test]
        public void ZerosToSave()
        {
            SaveFile file = new SaveFile("test", new byte[SaveFile.ParametersLengthInBytes], new byte[SaveFile.MapLengthInBytes]);

            SHA512 sha512 = new SHA512Managed();
            var exceptedHash = sha512.ComputeHash(new byte[SaveFile.InfoLengthInBytes]);
            sha512.Dispose();

            foreach (var param in file.ParametersInfo)
            {
                Assert.AreEqual(0, param);
            }

            foreach (var tile in file.MapInfo)
            {
                Assert.AreEqual(0, tile);
            }

            foreach (var b in file.FullInfo)
            {
                Assert.AreEqual(0, b);
            }

            for (int i = 0; i < 64; ++i)
            {
                Assert.AreEqual(exceptedHash[i], file.Hash[i]);
            }

            File.Delete(file.Path);
        }

        [Test]
        public void SaveRandomInfo()
        {
            byte[] parameters = new byte[SaveFile.ParametersLengthInBytes];
            byte[] map = new byte[SaveFile.MapLengthInBytes];
            Random r = new Random();
            r.NextBytes(parameters);
            r.NextBytes(map);
            byte[] info = parameters.Concat(map).ToArray();
            SaveFile file = new SaveFile("test", parameters, map);

            SHA512 sha512 = new SHA512Managed();
            var exceptedHash = sha512.ComputeHash(info);
            sha512.Dispose();

            for (int i = 0; i < SaveFile.ParametersLengthInBytes; ++i)
            {
                Assert.AreEqual(parameters[i], file.ParametersInfo[i]);
            }

            for (int i = 0; i < SaveFile.MapLengthInBytes; ++i)
            {
                Assert.AreEqual(map[i], file.MapInfo[i]);
            }

            for (int i = 0; i < SaveFile.InfoLengthInBytes; ++i)
            {
                Assert.AreEqual(info[i], file.FullInfo[i]);
            }

            for (int i = 0; i < 64; ++i)
            {
                Assert.AreEqual(exceptedHash[i], file.Hash[i]);
            }

            File.Delete(file.Path);
        }

        [Test]
        public void ExceptionIfTryingToSaveOverlengthInfo()
        {
            byte[] p = new byte[SaveFile.ParametersLengthInBytes];
            byte[] p_ol = new byte[SaveFile.ParametersLengthInBytes + 1];
            byte[] m = new byte[SaveFile.MapLengthInBytes];
            byte[] m_ol = new byte[SaveFile.MapLengthInBytes + 1];

            Assert.Throws<ArgumentException>(() => new SaveFile("test", p_ol, m));
            Assert.Throws<ArgumentException>(() => new SaveFile("test", p, m_ol));
            Assert.Throws<ArgumentException>(() => new SaveFile("test", p_ol, m_ol));
        }
    }
}