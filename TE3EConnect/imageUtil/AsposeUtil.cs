using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.imageUtil
{
    public class AsposeUtil
    {
        public AsposeUtil()
        {
            Aspose.Words.License license = new Aspose.Words.License();

            //Pass only the name of the license file embedded in the assembly
            license.SetLicense("Aspose.Total.lic");
        }

        public string ConvertWordToPdf(string wordDoc)
        {
            string outPdf = wordDoc.Replace(".doc", ".pdf");

            // Load the document from disk.
            Aspose.Words.Document doc = new Aspose.Words.Document(wordDoc);

            // Save as PDF
            doc.Save(outPdf);

            if(File.Exists(wordDoc))
            {
                try { File.Delete(wordDoc); }
                catch { }
            }

            return outPdf;
        }
    }
}
