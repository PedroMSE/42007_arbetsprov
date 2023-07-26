using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Etteplan_Arbetsprov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string XmlFile = @"C:\Users\pedro\source\repos\Etteplan_Arbetsprov\Etteplan_Arbetsprov\Files\sma_gentext.xml"; //Fetch the XML path

            var fileInfo = new FileInfo(XmlFile);//copy the info from the fetxhed xml file
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileInfo.FullName);//load the xml copied information into an object

            var node = xmlDocument.SelectSingleNode("//*[@id='42007']/target");//filter the ID and element to be copied to a new object

            System.Xml.Serialization.XmlSerializer newXml = new System.Xml.Serialization.XmlSerializer(node.GetType());//Convert the object into xml

            StreamWriter myWriter = new StreamWriter("File_42007.xml"); //Create a a writer and name the new file
            newXml.Serialize(myWriter, node); //Write the object information into the new file via stream
            myWriter.Close();

            Console.ReadKey();
        }
    }
}
