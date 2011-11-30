using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using Rumyantsev.Lab2.Railroad;

namespace Rumyantsev.Lab4.XMLAndSerialization.Serialization
{
    /// <summary>
    /// Data contract serialization
    /// </summary>
    class DataContractSerialization
    {
        private DataContractSerializer dcs;

        /// <summary>
        /// Constructor
        /// </summary>
        public DataContractSerialization()
        {
            dcs = new DataContractSerializer(typeof(Railroad));
        }

        /// <summary>
        /// Serialize information
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="railroad">Railroad</param>
        public void Serialize(Stream stream, Railroad railroad)
        {
            dcs.WriteObject(stream, railroad);
        }

        /// <summary>
        /// Deserialize information
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns>Railroad</returns>
        public Railroad Deserialize(Stream stream)
        {
            return (Railroad)dcs.ReadObject(stream);
        }
    }
}
