using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Rumyantsev.Lab2.Railroad;

namespace Rumyantsev.Lab4.XMLAndSerialization.Serialization
{
    /// <summary>
    /// Binary serialization 
    /// </summary>
    class BinarySerialization
    {
        private BinaryFormatter bf;

        /// <summary>
        /// Constructor
        /// </summary>
        public BinarySerialization()
        {
            bf = new BinaryFormatter();
        }

        /// <summary>
        /// Serialize information
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="railroad">Railroad</param>
        public void Serialize(Stream stream, Railroad railroad)
        {
            bf.Serialize(stream, railroad);
        }

        /// <summary>
        /// Deserialize information
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns>Railroad</returns>
        public Railroad Deserialize(Stream stream)
        {
            return (Railroad)bf.Deserialize(stream);
        }
    }
}
