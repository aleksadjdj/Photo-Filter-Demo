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
            bitmap.Save(newFileName, ImageFormat.Png);
        }

        private Bitmap ApplyFilter(Bitmap bitmap)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
               
                    Color pixelColor = bitmap.GetPixel(x, y);
                    Color newPixelColor = pixelColor.RandomFilterV5(x, y, bitmap.Width, bitmap.Height); //  <- apply filters
                    bitmap.SetPixel(x, y, newPixelColor);
                }
            }

            return bitmap;
        }
    }
}
