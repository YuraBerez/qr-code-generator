using System;
using System.Text;
using System;
using System.IO;
using System.Xml;
using System.Collections;
using SkiaSharp;
using System.Drawing;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using ZXing.SkiaSharp;

namespace qr_code_generator
{
    public class QRCodeGenerator
    {
        public void GenerateQRCode(string content, string outputPath)
        {
            // Create a QR code writer
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;

            // Set the encoding and error correction level
            barcodeWriter.Options = new QrCodeEncodingOptions
            {
                DisableECI = true, // Disable ECI encoding
                CharacterSet = "UTF-8",
                ErrorCorrection = ErrorCorrectionLevel.H
            };

            // Generate the QR code as a BitMatrix
            BitMatrix qrCodeMatrix = barcodeWriter.Encode(content);

            // Convert the BitMatrix to a Bitmap
            SKBitmap qrCodeBitmap = new SKBitmap(qrCodeMatrix.Width, qrCodeMatrix.Height);

            for (int x = 0; x < qrCodeMatrix.Width; x++)
            {
                for (int y = 0; y < qrCodeMatrix.Height; y++)
                {
                    qrCodeBitmap.SetPixel(x, y, qrCodeMatrix[x, y] ? SKColors.Yellow : SKColors.Blue);
                }
            }

            // saving image
            using (var imageStream = new SKFileWStream(outputPath))
            {
                qrCodeBitmap.Encode(imageStream, SKEncodedImageFormat.Png, 1500);
            }

            // Dispose of the QR code Bitmap
            qrCodeBitmap.Dispose();
        }
    }
}

