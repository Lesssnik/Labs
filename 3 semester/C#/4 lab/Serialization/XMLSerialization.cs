using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using Rumyantsev.Lab2.Railroad;

namespace Rumyantsev.Lab4.XMLAndSerialization.Serialization
{
    /// <summary>
    /// XML serialization
    /// </summary>
    class XMLSerialization
    {
        private XmlSerializer xs;

        /// <summary>
        /// Constructor
        /// </summary>
        public XMLSerialization()
        {
            xs = new XmlSerializer(typeof(Railroad));
        }

        /// <summary>
        /// Serialize information
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="railroad">Railroad</param>
        public void Serialize(Stream stream, Railroad railroad)
        {
            xs.Serialize(stream, railroad);
        }

        /// <summary>
        /// Deserialize information
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns>Railroad</returns>
        public Railroad Deserialize(Stream stream)
        {
            return (Railroad)xs.Deserialize(stream);
        }
    }
}
