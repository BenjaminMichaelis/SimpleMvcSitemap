using System.IO;

namespace DotnetSitemapGenerator.Serialization
{
    /// <summary>
    /// Provides serialization of data to xml.
    /// </summary>
    public interface IXmlSerializer
    {
        /// <summary>
        /// Serialize data to a stream.
        /// </summary>
        /// <param name="data">The generic data to serialize. The recommended data type is a <see cref="SitemapModel"/>.</param>
        string Serialize<T>(T data);

        /// <summary>
        /// Serialize data to a file.
        /// </summary>
        /// <param name="data">The generic data to serialize. The recommended data type is a <see cref="SitemapModel"/>.</param>
        /// <param name="fileLocation">The file name for the resulting file (preferably a .xml file).</param>
        /// <param name="readable">True/False; Whether or not the outputted xml stream should be 
        /// formatted in a way that is easily-readable to humans (formatted/indented).</param>
        string Serialize<T>(T data, string fileLocation, bool readable);

        /// <summary>
        /// Serialize data directly to a stream.
        /// </summary>
        /// <param name="data">The generic data to serialize. The recommended data type is a <see cref="SitemapModel"/>.</param>
        /// <param name="stream">The stream to serialize to.</param>
        /// <param name="readable">True/False; Whether or not the outputted xml stream should be 
        /// formatted in a way that is easily-readable to humans (formatted/indented).</param>
        void SerializeToStream<T>(T data, Stream stream, bool readable = false);
    }
}