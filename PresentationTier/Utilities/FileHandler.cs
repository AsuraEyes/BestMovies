using ImageMagick;
using Microsoft.AspNetCore.Components.Forms;

namespace PresentationTier.Utilities
{
    public static class FileHandler
    {
        public static byte[] CompressMagicImage(byte[] binaryData)
        {
            try
            {

                MemoryStream memstream = new MemoryStream();

                memstream.Write(binaryData, 0, binaryData.Length);

                memstream.Seek(0, SeekOrigin.Begin);

                MagickImage image = new MagickImage(binaryData);

                image.Scale(1024, 1024);

                return image.ToByteArray();

            }

            catch (Exception)

            {

                throw;

            }
        }
        public static async Task<byte[]> ConvertIBrowserFileToBytes(IBrowserFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        public static async Task<byte[]> CompressImage(IBrowserFile file, int quality)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                using var image = await Image.LoadAsync(file.OpenReadStream());

                // Apply compression by setting the quality
                var encoder = new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder
                {
                    Quality = quality // Set the desired image quality (0-100)
                };

                // Resize the image if needed
                // image.Mutate(x => x.Resize(...));

                // Compress and save the image to the memory stream
                image.Save(memoryStream, encoder);

                return memoryStream.ToArray();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}
