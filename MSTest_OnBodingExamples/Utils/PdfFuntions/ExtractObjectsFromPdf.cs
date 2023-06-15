using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;

namespace Utils;

public class ExtractObjectsFromPdf{

    public static Bitmap GetImagesFromPdf(string filePath, string elementKey, bool generateOutput)
    {
        var doc = PdfReader.Open(filePath);
        var page = doc.Pages[0];
        Bitmap bmp = new Bitmap(100,100);
        // Get resources dictionary
        PdfDictionary resources = page.Elements.GetDictionary("/Resources");
        if (resources != null)
        {
            //Console.WriteLine("Tiene recursos");
             // Get external objects dictionary
            PdfDictionary xObjects = resources.Elements.GetDictionary("/XObject");
            if (xObjects != null)
            {

                //ICollection<PdfItem> items = xObjects.Elements.Values;
                var item= xObjects.Elements[elementKey]; 
                
                // Iterate references to external objects
                //foreach (PdfItem item in items)
                //{
                    PdfReference reference = item as PdfReference;
                    if (reference != null)
                    {
                        PdfDictionary xObject = (PdfDictionary)reference.Value ;
                        // Is external object an image?
                        if (xObject != null && xObject.Elements.GetString("/Subtype") == "/Image"){
                            // do something with your image here 
                            // only the first image is handled here
                            bmp = ExportImage(xObject);
                            //bmp.Save($@"Docs\exported_{i}.png", System.Drawing.Imaging.ImageFormat.Bmp);
                            if(generateOutput){
                                 using (FileStream fs = new FileStream($@"Docs\SignatureReceipt.png", FileMode.Create, FileAccess.Write))
                                    {
                                        bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                                    }
                            }
                        }
                    }
                    
                
            }
        }
        return bmp;
    }

    private static Bitmap ExportImage(PdfDictionary image)
    {
        string filter = image.Elements.GetName("/Filter");
        switch (filter)
        {
            case "/FlateDecode":
                return ExportAsPngImage2(image);

            default:
                throw new ApplicationException(filter + " filter not implemented");
        }
    }

    private static Bitmap ExportAsPngImage2(PdfDictionary image)
    {
        int width = image.Elements.GetInteger(PdfImage.Keys.Width);
        int height = image.Elements.GetInteger(PdfImage.Keys.Height);
        //int bitsPerComponent = image.Elements.GetInteger(PdfImage.Keys.BitsPerComponent);
        var ColorSpace = image.Elements.GetArray(PdfImage.Keys.ColorSpace);
        //System.Drawing.Imaging.PixelFormat pixelFormat= System.Drawing.Imaging.PixelFormat.Format24bppRgb; //24 just for initalize
        System.Drawing.Imaging.PixelFormat pixelFormat;
        Bitmap bmp =new Bitmap(100,100);
        if (ColorSpace is null) //no colorspace.. bufferedimage?? is in BGR order instead of RGB so change the byte order. Right now it works
        {
            byte[] origineel_byte_boundary = image.Stream.UnfilteredValue;
            int bitsPerComponent = (origineel_byte_boundary.Length) / (width * height);

            switch (bitsPerComponent)
            {
                case 8:
                    pixelFormat = System.Drawing.Imaging.PixelFormat.Format8bppIndexed;
                    break;
                case 4:
                    pixelFormat = System.Drawing.Imaging.PixelFormat.Format32bppPArgb;
                    break;
                case 3:
                    pixelFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
                    break;
                default:
                    {
                        throw new Exception("Unknown pixel format " + bitsPerComponent);

                    }
            }
            bmp = new Bitmap(width, height, pixelFormat); 
            
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.WriteOnly, pixelFormat);
            System.Runtime.InteropServices.Marshal.Copy(origineel_byte_boundary, 0, bmd.Scan0, origineel_byte_boundary.Length);
            bmp.UnlockBits(bmd);
            /*
            bmp2 = new Bitmap(width, height, pixelFormat);
            for (int indicex = 0; indicex < bmp.Width; indicex++)
            {
                for (int indicey = 0; indicey < bmp.Height; indicey++)
                {
                    Color nuevocolor = bmp.GetPixel(indicex, indicey);
                    Color colorintercambiado = Color.FromArgb(nuevocolor.A, nuevocolor.B, nuevocolor.G, nuevocolor.R);
                    bmp2.SetPixel(indicex, indicey, colorintercambiado);
                }
            }
            
            bmp.Dispose();
            */
        }
        
        return bmp;
    }


    public static List<bool> GetHash(Bitmap bmpSource)
    {
        List<bool> lResult = new List<bool>();         
        //create new image with 16x16 pixel
        Bitmap bmpMin = new Bitmap(bmpSource, new Size(32, 32));
        for (int j = 0; j < bmpMin.Height; j++)
        {
            for (int i = 0; i < bmpMin.Width; i++)
            {
                //reduce colors to true / false                
                lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
            }             
        }
        return lResult;
    }


   public static Bitmap Base64StringToBitmap(string base64String,bool generateOutput)
    {
        Bitmap bmpReturn = null;

        byte[] byteBuffer = Convert.FromBase64String(base64String);
        using(MemoryStream memoryStream = new MemoryStream(byteBuffer)){;

            memoryStream.Position = 0;
            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);
        }
        if(generateOutput){
                using (FileStream fs = new FileStream($@"Docs\SignatureReceiptFromWeb.png", FileMode.Create, FileAccess.Write))
                {
                    bmpReturn.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                }
        }

        return bmpReturn;
    }

}