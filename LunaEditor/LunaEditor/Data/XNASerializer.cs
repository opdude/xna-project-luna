using System.IO;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace LunaEditor
{
    /// <summary>
    /// This file may be against EULA have to check if we
    /// distribute this
    /// </summary>
    static class XnaSerializer
    {
        public static void Serialize<T>(string filename, T data)
        {
            XmlWriterSettings settings = new XmlWriterSettings {Indent = true};

            using (XmlWriter writer = XmlWriter.Create(filename, settings))
            {
                IntermediateSerializer.Serialize<T>(writer, data, null);
            }
        }

        public static T Deserialize<T>(string filename)
        {
            T data;

            using (FileStream fileStream = new FileStream(filename, FileMode.Open))
            {
                using (XmlReader reader  = XmlReader.Create(fileStream))
                {
                    data = IntermediateSerializer.Deserialize<T>(reader, null);
                }
            }

            return data;
        }
    }
}
