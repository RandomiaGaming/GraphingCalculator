using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphingCalculator
{
    public static class PDLogoRenderrer
    {
        public static System.Drawing.Color DesmosBlue = System.Drawing.Color.FromArgb(255, 54, 109, 179);
        public static System.Drawing.Color DesmosRed = System.Drawing.Color.FromArgb(255, 199, 71, 63);
        public static System.Drawing.Color PornHubOrange = System.Drawing.Color.FromArgb(255, 255, 154, 0);
        public static System.Drawing.Bitmap Render(int pixelWidth = 256, int pixleHeight = 256, double playCornerRoundness = 0.25, double arrowTailWidth = 0.3, double arrowPointHeight = 0.35, double arrowCornerRoundness = 0.4)
        {
            if (pixelWidth <= 0)
            {
                throw new Exception("pixelWidth must be greater than 0.");
            }

            if (pixleHeight <= 0)
            {
                throw new Exception("pixelHeight must be greater than 0.");
            }

            if (playCornerRoundness < 0)
            {
                throw new Exception("playCornerRoundness must be greater than 0.");
            }
            if (playCornerRoundness > 1)
            {
                throw new Exception("playCornerRoundness must be less than 1.");
            }

            if (arrowTailWidth < 0)
            {
                throw new Exception("arrowTailWidth must be greater than 0.");
            }
            if (arrowTailWidth > 1)
            {
                throw new Exception("arrowTailWidth must be less than 1.");
            }

            if (arrowPointHeight < 0)
            {
                throw new Exception("arrowPointHeight must be greater than 0.");
            }
            if (arrowPointHeight > 1)
            {
                throw new Exception("arrowPointHeight must be less than 1.");
            }

            if (arrowCornerRoundness < 0)
            {
                throw new Exception("arrowCornerRoundness must be greater than 0.");
            }
            if (arrowCornerRoundness > 1)
            {
                throw new Exception("arrowCornerRoundness must be less than 1.");
            }

            System.Drawing.Bitmap output = new System.Drawing.Bitmap(pixelWidth, pixleHeight);

            double sinOf60 = Math.Sqrt(3) / 2;

            double playCornerRadius = playCornerRoundness / 2;
            double playSideLength = 1 - playCornerRoundness;
            double playWidthBuffer = (1 - playCornerRoundness - (playSideLength * sinOf60)) / 2;

            double arrowTailHalfWidth = arrowTailWidth / 2;
            double arrowCornerRadius = arrowCornerRoundness * arrowTailHalfWidth;

            Fill(output, System.Drawing.Color.Transparent);

            DrawCircle(output, DesmosBlue, playCornerRadius + playWidthBuffer, playCornerRadius, playCornerRadius);
            DrawCircle(output, DesmosBlue, playCornerRadius + playWidthBuffer, playCornerRadius + playSideLength, playCornerRadius);
            DrawCircle(output, DesmosBlue, playCornerRadius + playWidthBuffer + (playSideLength * sinOf60), 0.5, playCornerRadius);

            DrawTriangle(output, DesmosBlue, playWidthBuffer, playCornerRadius, playWidthBuffer, playCornerRadius + playSideLength, (1.5 * playCornerRadius) + playWidthBuffer, playCornerRadius + playSideLength + (playCornerRadius * sinOf60));
            DrawTriangle(output, DesmosBlue, playWidthBuffer, playCornerRadius, (1.5 * playCornerRadius) + playWidthBuffer, playCornerRadius + playSideLength + (playCornerRadius * sinOf60), (1.5 * playCornerRadius) + (playSideLength * sinOf60) + playWidthBuffer, playCornerRadius + (playSideLength / 2) + (playCornerRadius * sinOf60));
            DrawTriangle(output, DesmosBlue, playWidthBuffer, playCornerRadius, (1.5 * playCornerRadius) + (playSideLength * sinOf60) + playWidthBuffer, playCornerRadius + (playSideLength / 2) + (playCornerRadius * sinOf60), (1.5 * playCornerRadius) + (playSideLength * sinOf60) + playWidthBuffer, playCornerRadius + (playSideLength / 2) - (playCornerRadius * sinOf60));
            DrawTriangle(output, DesmosBlue, playWidthBuffer, playCornerRadius, (1.5 * playCornerRadius) + (playSideLength * sinOf60) + playWidthBuffer, playCornerRadius + (playSideLength / 2) - (playCornerRadius * sinOf60), (1.5 * playCornerRadius) + playWidthBuffer, playCornerRadius - (playCornerRadius * sinOf60));

            DrawCircle(output, DesmosRed, 0.5 - arrowTailHalfWidth + arrowCornerRadius, 1 - arrowCornerRadius, arrowCornerRadius);
            DrawCircle(output, DesmosRed, 0.5 + arrowTailHalfWidth - arrowCornerRadius, 1 - arrowCornerRadius, arrowCornerRadius);

            DrawRectangle(output, DesmosRed, 0.5 - arrowTailHalfWidth + arrowCornerRadius, 1 - arrowCornerRadius, 0.5 + arrowTailHalfWidth - arrowCornerRadius, 1);

            if(arrowPointHeight < 1 - arrowCornerRadius)
            {
                DrawRectangle(output, DesmosRed, 0.5 - arrowTailHalfWidth, arrowPointHeight, 0.5 + arrowTailHalfWidth, 1 - arrowCornerRadius);
            }

            DrawTriangle(output, DesmosRed, 0, arrowPointHeight, 0.5, 0, 1, arrowPointHeight);

            return output;
        }
        public static System.Drawing.Bitmap RenderV2(int pixelWidth = 256, int pixleHeight = 256)
        {
            if (pixelWidth <= 0)
            {
                throw new Exception("pixelWidth must be greater than 0.");
            }

            if (pixleHeight <= 0)
            {
                throw new Exception("pixelHeight must be greater than 0.");
            }

            System.Drawing.Bitmap output = new System.Drawing.Bitmap(pixelWidth, pixleHeight);

            Fill(output, System.Drawing.Color.White);

            DrawEllipse(output, PornHubOrange, 0.5, 0.5, 0.5, 1);

            return output;
        }

        private static void Fill(System.Drawing.Bitmap sourceBitmap, System.Drawing.Color color)
        {
            if (sourceBitmap is null)
            {
                throw new Exception("sourceBitmap cannot be null.");
            }

            int pixelWidth = sourceBitmap.Width;
            int pixelHeight = sourceBitmap.Height;

            for (int x = 0; x < pixelWidth; x++)
            {
                for (int y = 0; y < pixelHeight; y++)
                {
                    sourceBitmap.SetPixel(x, y, color);
                }
            }
        }
        private static void DrawRectangle(System.Drawing.Bitmap sourceBitmap, System.Drawing.Color color, double minX, double minY, double maxX, double maxY)
        {
            if (sourceBitmap is null)
            {
                throw new Exception("sourceBitmap cannot be null.");
            }

            if (minX > maxX)
            {
                throw new Exception("minX must be less than or equal to maxX.");
            }
            if (minY > maxY)
            {
                throw new Exception("minY must be less than or equal to maxY.");
            }

            int pixelWidth = sourceBitmap.Width;
            int pixelHeight = sourceBitmap.Height;

            for (int x = 0; x < pixelWidth; x++)
            {
                for (int y = 0; y < pixelHeight; y++)
                {
                    double scaledX = (x + 0.5) / pixelWidth;
                    double scaledY = 1 - ((y + 0.5) / pixelHeight);

                    if (scaledX >= minX && scaledX <= maxX && scaledY >= minY && scaledY <= maxY)
                    {
                        sourceBitmap.SetPixel(x, y, color);
                    }
                }
            }
        }
        private static void DrawCircle(System.Drawing.Bitmap sourceBitmap, System.Drawing.Color color, double centriodX, double centriodY, double radius)
        {
            if (sourceBitmap is null)
            {
                throw new Exception("sourceBitmap cannot be null.");
            }

            int pixelWidth = sourceBitmap.Width;
            int pixelHeight = sourceBitmap.Height;

            double radiusSquared = radius * radius;

            for (int x = 0; x < pixelWidth; x++)
            {
                for (int y = 0; y < pixelHeight; y++)
                {
                    double scaledX = (x + 0.5) / pixelWidth;
                    double scaledY = 1 - ((y + 0.5) / pixelHeight);

                    double localX = scaledX - centriodX;
                    double localY = scaledY - centriodY;

                    if ((localX * localX) + (localY * localY) <= radiusSquared)
                    {
                        sourceBitmap.SetPixel(x, y, color);
                    }
                }
            }
        }
        private static void DrawTriangle(System.Drawing.Bitmap sourceBitmap, System.Drawing.Color color, double point0X, double point0Y, double point1X, double point1Y, double point2X, double point2Y)
        {
            if (sourceBitmap is null)
            {
                throw new Exception("sourceBitmap cannot be null.");
            }

            int pixelWidth = sourceBitmap.Width;
            int pixelHeight = sourceBitmap.Height;

            for (int x = 0; x < pixelWidth; x++)
            {
                for (int y = 0; y < pixelHeight; y++)
                {
                    double scaledX = (x + 0.5) / pixelWidth;
                    double scaledY = 1 - ((y + 0.5) / pixelHeight);

                    if (PointInTriangle(scaledX, scaledY, point0X, point0Y, point1X, point1Y, point2X, point2Y))
                    {
                        sourceBitmap.SetPixel(x, y, color);
                    }
                }
            }
        }
        private static void DrawEllipse(System.Drawing.Bitmap sourceBitmap, System.Drawing.Color color, double centriodX, double centriodY, double width, double height)
        {
            if (sourceBitmap is null)
            {
                throw new Exception("sourceBitmap cannot be null.");
            }

            if (width < 0)
            {
                throw new Exception("width must be greater than or equal to 0.");
            }
            if (height < 0)
            {
                throw new Exception("height must be greater than or equal to 0.");
            }

            int pixelWidth = sourceBitmap.Width;
            int pixelHeight = sourceBitmap.Height;

            double halfWidth = width / 2;
            double halfHeight = height / 2;

            double halfWidthSquared = halfWidth * halfWidth;
            double halfHeightSquared = halfHeight * halfHeight;

            for (int x = 0; x < pixelWidth; x++)
            {
                for (int y = 0; y < pixelHeight; y++)
                {
                    double scaledX = (x + 0.5) / pixelWidth;
                    double scaledY = 1 - ((y + 0.5) / pixelHeight);

                    double localX = scaledX - centriodX;
                    double localY = scaledY - centriodY;

                    if (((localX * localX) / halfWidthSquared) + ((localY * localY) / halfHeightSquared) <= 1)
                    {
                        sourceBitmap.SetPixel(x, y, color);
                    }
                }
            }
        }
        private static void DrawRoundedRectangle(System.Drawing.Bitmap sourceBitmap, System.Drawing.Color color, double minX, double minY, double maxX, double maxY, double cornerRadius)
        {
            if (sourceBitmap is null)
            {
                throw new Exception("sourceBitmap cannot be null.");
            }

            if (minX > maxX)
            {
                throw new Exception("minX must be less than or equal to maxX.");
            }
            if (minY > maxY)
            {
                throw new Exception("minY must be less than or equal to maxY.");
            }

            if (cornerRadius < 0)
            {
                throw new Exception("cornerRadius must be greater than or equal to 0.");
            }

            double width = maxX - minX;
            double height = maxY - minY;

            double cornerDiameter = cornerRadius * 2;

            if (cornerDiameter > width || cornerDiameter > height)
            {
                throw new Exception("cornerRadius is too big to fit within this rectangle.");
            }

            DrawRectangle(sourceBitmap, color, minX + cornerRadius, minY, maxX - cornerRadius, maxY);
            DrawRectangle(sourceBitmap, color, minX, minY + cornerRadius, maxX, maxY - cornerRadius);

            DrawCircle(sourceBitmap, color, minX + cornerRadius, minY + cornerRadius, cornerRadius);
            DrawCircle(sourceBitmap, color, minX + cornerRadius, maxY - cornerRadius, cornerRadius);
            DrawCircle(sourceBitmap, color, maxX - cornerRadius, minY + cornerRadius, cornerRadius);
            DrawCircle(sourceBitmap, color, maxX - cornerRadius, maxY - cornerRadius, cornerRadius);
        }

        private static bool PointInTriangle(double sampleX, double sampleY, double point0X, double point0Y, double point1X, double point1Y, double point2X, double point2Y)
        {
            double d0 = (sampleX - point1X) * (point0Y - point1Y) - (point0X - point1X) * (sampleY - point1Y);
            double d1 = (sampleX - point2X) * (point1Y - point2Y) - (point1X - point2X) * (sampleY - point2Y);
            double d2 = (sampleX - point0X) * (point2Y - point0Y) - (point2X - point0X) * (sampleY - point0Y);

            bool hasNegative = (d0 < 0) || (d1 < 0) || (d2 < 0);
            bool hasPositive = (d0 > 0) || (d1 > 0) || (d2 > 0);

            return !(hasNegative && hasPositive);
        }
    }
}