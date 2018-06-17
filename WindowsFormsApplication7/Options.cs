using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApplication7
{
    public class Options
    {
        public bool AutoSelectFilm;
        public bool AutoSelectDate;

    }

    public class OptionsService
    {
        public void Save(Options options)
        {
            var xmlSerializer = new XmlSerializer(typeof(Options));
            using (TextWriter writer = new StreamWriter("options.xml"))
            {
                xmlSerializer.Serialize(writer, options);
            }
        }

        public Options Load()
        {
            if (File.Exists("options.xml"))
            {
                var xmlSerializer = new XmlSerializer(typeof(Options));
                using (TextReader reader = new StreamReader("options.xml"))
                {
                    return (Options)xmlSerializer.Deserialize(reader);
                }
            }

            return new Options();
        }
    }
}
