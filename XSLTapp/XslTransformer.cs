using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Resources;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace XSLTapp
{
    //  Class to perform the xslt transformation
    public static class XslTransformer
    {
        public static void Transform(string xslFile, string xmlFile, string resultXmlFile)
        {
            try
            {
                XslCompiledTransform transform = new XslCompiledTransform();

                transform.Load(xslFile);
                transform.Transform(xmlFile, resultXmlFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
