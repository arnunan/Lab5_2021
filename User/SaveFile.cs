using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace User
{
    public class SaveFile
    {
        #region Consts
        public const int ParameterLengthInBytes = 2;
        public const int CountOfParameters = 6;
        public const int TileLengthInBytes = 1;
        public const int CountOfTilesInMap = Map.Size * Map.Size;

        public const int ParametersLengthInBytes = ParameterLengthInBytes * CountOfParameters;
        public const int MapLengthInBytes = TileLengthInBytes * CountOfTilesInMap;

        public const int InfoLengthInBytes = ParametersLengthInBytes + MapLengthInBytes;
        #endregion

        public string Path { get; }

        public byte[] ParametersInfo
        {
            get => ReadFile(0, ParametersLengthInBytes);
            set {
                if (value.Length != ParametersLengthInBytes)
                    throw new ArgumentException($"{value.Length} != {ParametersLengthInBytes}");
                WriteFile(0, ParametersLengthInBytes, value);
                }
        }

        public byte[] MapInfo
        {
            get => ReadFile(ParametersLengthInBytes, MapLengthInBytes);
            set
            {
                if (value.Length != MapLengthInBytes)
                    throw new ArgumentException($"{value.Length} != {MapLengthInBytes}");
                WriteFile(ParametersLengthInBytes, MapLengthInBytes, value);
            }
        }

        public byte[] FullInfo => ReadFile(0, InfoLengthInBytes);

        public byte[] Hash => ReadFile(InfoLengthInBytes, 64);

        public SaveFile(string path)
        {
            Path = path;
        }

        public SaveFile(string name, byte[] parameters, byte[] map)
        {
            string newFile = SystemFiles.SaveFilesFolder + $"{name}.save";
            Path = newFile;
            var f = File.Create(Path);
            f.Close();
            WriteFile(0, InfoLengthInBytes, new byte[InfoLengthInBytes]);
            ParametersInfo = parameters;
            MapInfo = map;
        }

        public void WriteFile(int offset, int count, byte[] info)
        {
            FileInfo f = new FileInfo(Path);

            byte[] infoToWrite = ReadFile(0, offset).Concat(info).ToArray();

            var fStream = f.OpenWrite();
            fStream.Write(infoToWrite,
                0, 
                offset + count);
            fStream.Close();

            SHA512 sha512 = new SHA512Managed();
            byte[] hash = sha512.ComputeHash(FullInfo);
            sha512.Dispose();

            byte[] hashToWrite = ReadFile(0, InfoLengthInBytes).Concat(hash).ToArray();

            fStream = f.OpenWrite();
            fStream.Write(hashToWrite,
                0, InfoLengthInBytes + 64);
            fStream.Close();
        }

        public byte[] ReadFile(int offset, int count)
        {
            var file = new byte[InfoLengthInBytes + 64];
            
            FileInfo f = new FileInfo(Path);
            var fStream = f.OpenRead();
            fStream.Read(file, 0, InfoLengthInBytes + 64);
            fStream.Close();

            return file
                .Skip(offset)
                .Take(count)
                .ToArray(); ;
        }
    }
}
