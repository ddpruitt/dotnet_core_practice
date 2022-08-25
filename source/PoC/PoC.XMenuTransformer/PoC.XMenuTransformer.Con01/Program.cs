using System.Xml.Linq;
using System.Xml.Xsl;
using System.Xml;

string xslt = File.ReadAllText(@"XSLTFile1.xslt");
string xml = File.ReadAllText(@"XMLFile1.xml");

var xDoc = new XmlDocument();
xDoc.Load(new StringReader(xml));

var newDocument = new XDocument();

using (var stringReader = new StringReader(xslt))
{
    using (XmlReader xsltReader = XmlReader.Create(stringReader))
    {
        var transformer = new XslCompiledTransform();
        transformer.Load(xsltReader);
        using (XmlReader oldDocumentReader = xDoc.CreateNavigator().ReadSubtree())
        {
            using (XmlWriter newDocumentWriter = newDocument.CreateWriter())
            {
                transformer.Transform(oldDocumentReader, newDocumentWriter);
            }
        }
    }
}

string result = newDocument.ToString();
Console.WriteLine(result);