using System;
using System.Drawing;
using System.Linq;

namespace PhotoEditorDemo
{
    public static class Filter
    {
        static byte A;
        static byte R;
        static byte G;
        static byte B;

        private static void SetPixelColor(Color pixelColor)
        {
            A = pixelColor.A;
            R = pixelColor.R;
            G = pixelColor.G;
            B = pixelColor.B;
        }

        public static Color ThreeColor(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            if (R > G && R > B)
            {
                R = 255; G = 0; B = 0;
            }
            if (G > R && G > B)
            {
                R = 0; G = 255; B = 0;
            }
            if (B > G && B > R)
            {
                R = 0; G = 0; B = 255;
            }


            if (R == G)
            {
                R = 0; G = 0; B = 255;
            }

            if (R == B)
            {
                R = 0; G = 255; B = 0;
            }

            if (G == B)
            {
                R = 255; G = 0; B = 0;
            }


            return Color.FromArgb(A, R, G, B);
        }
        public static Color RandomNoiseV1(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            Random random = new Random();
            R = (byte)(R - random.Next(byte.MaxValue));
            G = (byte)(G - random.Next(byte.MaxValue));
            B = (byte)(B - random.Next(byte.MaxValue));

            return Color.FromArgb(A, R, G, B);
        }
        public static Color RandomNoiseV2(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            Random random = new Random();
            byte tempByte = (byte)random.Next(byte.MaxValue);
            R = (byte)(R - tempByte);
            G = (byte)(G - tempByte);
            B = (byte)(B - tempByte);

            return Color.FromArgb(A, R, G, B);
        }
        public static Color RandomNoiseV3(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            Random random = new Random();
            // random bits from 0-16
            byte bytes = (byte)random.Next(1, 4);
            R = (byte)(R << bytes);
            G = (byte)(G << bytes);
            B = (byte)(B << bytes);

            return Color.FromArgb(A, R, G, B);
        }
        public static Color RandomNoiseV4(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            Random random = new Random();
            byte bytes = (byte)random.Next(byte.MaxValue / 4);
            R = (byte)(R ^ bytes);
            G = (byte)(G ^ bytes);
            B = (byte)(B ^ bytes);

            return Color.FromArgb(A, R, G, B);
        }
        public static Color GrayscaleAverage(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            int avr = (R + G + B) / 3;

            return Color.FromArgb(A, avr, avr, avr);
        }
        public static Color GrayscaleMax(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            int[] arr = { R, G, B };
            int maxValue = arr.Max();

            return Color.FromArgb(A, maxValue, maxValue, maxValue);
        }
        public static Color GrayscaleMin(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            int[] arr = { R, G, B };
            int maxValue = arr.Min();

            return Color.FromArgb(A, maxValue, maxValue, maxValue);
        }
        public static Color BlackWhite(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            int avr = (R + G + B) / 3;

            if (avr < 128)
                R = G = B = 0;
            else
                R = G = B = 255;

            return Color.FromArgb(A, R, G, B);

        }
        public static Color BlackWhiteNegative(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            int avr = (R + G + B) / 3;

            if (avr < 128)
                R = G = B = 255;
            else
                R = G = B = 0;

            return Color.FromArgb(A, R, G, B);

        }
        public static Color BlackRed(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            int avr = (R + G + B) / 3;

            if (avr < 128)
            {
                R = G = B = 0;
            }
            else
            {
                R = 255;
                G = B = 0;
            }

            return Color.FromArgb(A, R, G, B);

        }
        public static Color RedPalletOnly(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            G = B = 0;

            return Color.FromArgb(A, R, G, B);

        }
        public static Color GreenPalletOnly(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            R = B = 0;

            return Color.FromArgb(A, R, G, B);

        }
        public static Color BluePalletOnly(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            R = G = 0;

            return Color.FromArgb(A, R, G, B);

        }
        public static Color Cyan(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            R = 0;

            return Color.FromArgb(A, R, G, B);

        }
        public static Color Purple(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            G = 0;

            return Color.FromArgb(A, R, G, B);

        }
        public static Color Yellow(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            B = 0;

            return Color.FromArgb(A, R, G, B);

        }
        public static Color InvertColor(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            R = (byte)(255 - R);
            G = (byte)(255 - G);
            B = (byte)(255 - B);

            return Color.FromArgb(A, R, G, B);

        }
        public static Color ToGBR(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            return Color.FromArgb(A, G, B, R);

        }
        public static Color ToBRG(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            return Color.FromArgb(A, B, R, G);
        }
        public static Color ToGRB(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            return Color.FromArgb(A, G, R, B);
        }
        public static Color ToRBG(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            return Color.FromArgb(A, R, B, G);
        }
        public static Color EightBitColor(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            if (R < 64) R = 0;
            else if (R < 128) R = 64;
            else if (R < 192) R = 128;
            else R = 255;

            if (G < 64) G = 0;
            else if (G < 128) G = 64;
            else if (G < 192) G = 128;
            else G = 255;

            if (B < 64) B = 0;
            else if (B < 128) B = 64;
            else if (B < 192) B = 128;
            else B = 255;

            return Color.FromArgb(A, R, G, B);

        }
        public static Color Test(this Color pixelColor)
        {
            SetPixelColor(pixelColor);

            if (R < 128) R = 0;
            else R = 255;

            if (G < 128) G = 0;
            else G = 255;

            if (B < 128) B = 0;
            else B = 255;

            return Color.FromArgb(A, R, G, B);

        }
    }
}
