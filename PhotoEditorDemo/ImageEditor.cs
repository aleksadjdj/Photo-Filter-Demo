using System.Drawing;
using System.Drawing.Imaging;

namespace PhotoEditorDemo
{
    public class ImageEditor
    {
        private readonly Bitmap bitmap;
        public ImageEditor(string fileName, string newFileName)
        {
            bitmap = new Bitmap(fileName);
            bitmap = ApplyFilter(bitmap);

            var outputImage = new Bitmap(bitmap);
            bitmap.Dispose();
            string newPath = newFileName;
            outputImage.Save($"{newPath}", ImageFormat.Jpeg);
            outputImage.Dispose();
        }

        private Bitmap ApplyFilter(Bitmap bitmap)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    Color newPixelColor = pixelColor.RemoveGrayNoiseV1();  //  <- apply filters
                    bitmap.SetPixel(x, y, newPixelColor);
                }
            }

            return bitmap;
        }
    }
}
