
namespace PdfFuntions;

using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

[TestClass]
[TestCategory("PdfFuntions")]
public class TestPdfFuntions{


        [TestMethod]
        public void TestLoadData()
        {
            
            string docFilePath = @"Docs\PdfPrueba.pdf";
            if(File.Exists(docFilePath)){ System.IO.File.Delete(docFilePath);}
            CreatePdf.Create(docFilePath);
            Assert.IsTrue(File.Exists(docFilePath),"Documento NO Creado");
        }


         [TestMethod]
        public void TestExtractPicturesFromPDF()
        {
            string docFilePath = @"Docs\Recibo_ConFirma.pdf";
            using(ExtractObjectsFromPdf.GetImagesFromPdf(docFilePath,"/Im10",true)){};
            int imageNumber = Directory.GetFiles(@"Docs\", "*.png").Length;
            Assert.IsTrue( imageNumber > 0,"Imagenes no Creadas");
        }

        [TestMethod]
        public void CompareImages(){
            Bitmap image1 = (Bitmap) Image.FromFile("Docs/Comparar/SignaturePad_Image_WebPage.png");
            List<bool> hash_1= ExtractObjectsFromPdf.GetHash(image1);

            Bitmap image2 = (Bitmap) Image.FromFile("Docs/Comparar/SignatureReceipt.png");
            List<bool> hash_2= ExtractObjectsFromPdf.GetHash(image2);
            int equalElements = hash_1.Zip(hash_2, (i, j) => i == j).Count(eq => eq);
            Assert.AreEqual(1024,equalElements);
        }


        [TestMethod]
        public void CompareImages_Test(){
            int equalElements = 0;
            string docFilePath = @"Docs\Recibo_ConFirma.pdf";
            using(Bitmap image1 = ExtractObjectsFromPdf.GetImagesFromPdf(docFilePath,"/Im10",true)){
                List<bool> hash_1= ExtractObjectsFromPdf.GetHash(image1);
                using(Bitmap image2 = ExtractObjectsFromPdf.Base64StringToBitmap(File.ReadAllText("Docs/SignaturePad_Image_WebPage.base64"),true)){
                    List<bool> hash_2= ExtractObjectsFromPdf.GetHash(image2);
                    equalElements = hash_1.Zip(hash_2, (i, j) => i == j).Count(eq => eq);   
                }
            };

            Assert.AreEqual(1024,equalElements);
        }

        [TestCleanup]
        public void Dispose(){
            foreach(string sFile in System.IO.Directory.GetFiles(@"Docs\", "*.png"))
            {   
                System.IO.File.Delete(sFile);
            }
        }



}