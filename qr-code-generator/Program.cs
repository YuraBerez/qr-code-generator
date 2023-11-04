using qr_code_generator;

Console.WriteLine("Enter your QR code text:");
var qrCodeText = Console.ReadLine();

if (string.IsNullOrEmpty(qrCodeText))
{
    Console.WriteLine("The entered text is empty.");
    return;
}

new QRCodeGenerator().GenerateQRCode(qrCodeText, "res.png");
Console.WriteLine("QR code successfully created and saved as 'res.png'");
