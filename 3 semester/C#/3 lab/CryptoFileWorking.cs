using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rumyantsev.Lab2.Railroad;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;

namespace Rumyantsev.Lab3
{
    /// <summary>
    /// Save and load crypted information about railroad
    /// </summary>
    class CryptoFileWorking:TextFileWorking
    {
        /// <summary>
        /// Save information about railroad with encrypting
        /// </summary>
        /// <param name="railroad">Railroad, that should be saved</param>
        /// <param name="stream">Stream</param>
        /// <param name="Key">Key for encrypting</param>
        /// <param name="IV">Vector for encrypting</param>
        public void SaveCryptoRailroad(Railroad railroad, Stream stream, byte[] Key, byte[] IV)
        {
            GZipStream gzs = new GZipStream(stream, CompressionMode.Compress, true);
            Rijndael RijndaelAlg = Rijndael.Create();
            CryptoStream cs = new CryptoStream(gzs, RijndaelAlg.CreateEncryptor(Key, IV), CryptoStreamMode.Write);

            SaveRailroad(cs, railroad);

            cs.Close();
            gzs.Close();
        }

        /// <summary>
        /// Load information about railroad from encrypted file
        /// </summary>
        /// <param name="stream">Stream, that contain path to the file</param>
        /// <param name="Key">Key for decrypting</param>
        /// <param name="IV">vector for decrypting</param>
        /// <returns></returns>
        public Railroad LoadCryptoRailroad(Stream stream, byte[] Key, byte[] IV)
        {
            GZipStream gzs = new GZipStream(stream, CompressionMode.Decompress, true);
            Rijndael RijndaelAlg = Rijndael.Create();
            CryptoStream cs = new CryptoStream(gzs, RijndaelAlg.CreateDecryptor(Key, IV), CryptoStreamMode.Read);

            Railroad railroad = LoadRailroad(cs);

            cs.Close();
            gzs.Close();

            return railroad;
        }
    }
}
