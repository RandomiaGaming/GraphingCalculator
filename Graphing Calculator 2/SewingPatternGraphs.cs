using System;
using System.Drawing;
public static class SewingPatternGraphs
{
    public static Bitmap RenderPaw(float width = 3.0f, float height = 3.0f, float curveRadius = 1.0f, int pixelsPerInch = 100)
    {
        int pixelWidth = MathHelper.RoundToInt(width * pixelsPerInch);
        int pixelHeight = MathHelper.RoundToInt(height * pixelsPerInch);
        Bitmap output = new Bitmap(pixelWidth, pixelHeight);
        output.SetResolution(pixelsPerInch, pixelsPerInch);

        Graphics graphics = Graphics.FromImage(output);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        graphics.Clear(Color.White);
        
        float curveDiameter = curveRadius * 2.0f;
        RectangleF bigRect = new RectangleF(0.0f, 0.0f, width, height - curveRadius);
        graphics.FillRectangle(blackBrush, FlipYAxis(RoundToPixelGrid(ScaleInchesToPixels(bigRect, output)), output));
        RectangleF smallRect = new RectangleF(curveRadius, 0.0f, width - curveDiameter, height);
        graphics.FillRectangle(blackBrush, FlipYAxis(RoundToPixelGrid(ScaleInchesToPixels(smallRect, output)), output));
        RectangleF leftCircleRect = new RectangleF(0.0f, height - curveDiameter, curveDiameter, curveDiameter);
        graphics.FillEllipse(blackBrush, FlipYAxis(RoundToPixelGrid(ScaleInchesToPixels(leftCircleRect, output)), output));
        RectangleF rightCircleRect = new RectangleF(width - curveDiameter, height - curveDiameter, curveDiameter, curveDiameter);
        graphics.FillEllipse(blackBrush, FlipYAxis(RoundToPixelGrid(ScaleInchesToPixels(rightCircleRect, output)), output));

        float insetFactor = 0.9f;
        float insetX = (width * (1.0f - insetFactor)) / 2.0f;
        float insetY = (width * (1.0f - insetFactor)) / 2.0f;
        bigRect = new RectangleF((bigRect.X * insetFactor) + insetX, (bigRect.Y * insetFactor) + insetY, bigRect.Width * insetFactor, bigRect.Height * insetFactor);
        graphics.FillRectangle(whiteBrush, FlipYAxis(RoundToPixelGrid(ScaleInchesToPixels(bigRect, output)), output));
       smallRect = new RectangleF((smallRect.X * insetFactor) + insetX, (smallRect.Y * insetFactor) + insetY, smallRect.Width * insetFactor, smallRect.Height * insetFactor);
        graphics.FillRectangle(whiteBrush, FlipYAxis(RoundToPixelGrid(ScaleInchesToPixels(smallRect, output)), output));
        leftCircleRect = new RectangleF((leftCircleRect.X * insetFactor) + insetX, (leftCircleRect.Y * insetFactor) + insetY, leftCircleRect.Width * insetFactor, leftCircleRect.Height * insetFactor);
        graphics.FillEllipse(whiteBrush, FlipYAxis(RoundToPixelGrid(ScaleInchesToPixels(leftCircleRect, output)), output));
        rightCircleRect = new RectangleF((rightCircleRect.X * insetFactor) + insetX, (rightCircleRect.Y * insetFactor) + insetY, rightCircleRect.Width * insetFactor, rightCircleRect.Height * insetFactor);
        graphics.FillEllipse(whiteBrush, FlipYAxis(RoundToPixelGrid(ScaleInchesToPixels(rightCircleRect, output)), output));

        graphics.Dispose();
        return output;
    }

    public static Bitmap RenderGore(double radius = 4.615, int numberOfSegments = 4, int pixelsPerInch = 100)
    {
        double pi = Math.PI;
        double circumfrence = 2.0 * pi * radius;

        double width = circumfrence / numberOfSegments;
        double height = circumfrence / 4.0;

        int pixelWidth = MathHelper.RoundToInt(width * pixelsPerInch);
        int pixelHeight = MathHelper.RoundToInt(height * pixelsPerInch);
        Bitmap output = new Bitmap(pixelWidth, pixelHeight);
        output.SetResolution(pixelsPerInch, pixelsPerInch);

        Graphics graphics = Graphics.FromImage(output);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        graphics.Clear(Color.White);

        for (int pixelY = 0; pixelY < pixelHeight; pixelY++)
        {
            double theta = ((pixelY / (double)pixelHeight) * pi) / 2.0;
            double sliceRadius = MathHelper.Cos(theta) * radius;
            double sliceCircumfrence = 2.0 * pi * sliceRadius;
            double segmentWidth = sliceCircumfrence / numberOfSegments;
            int pixelSegmentWidth = MathHelper.RoundToInt(segmentWidth * pixelsPerInch);
            graphics.FillRectangle(blackBrush, FlipYAxis(new Rectangle((pixelWidth - pixelSegmentWidth) / 2, pixelY, pixelSegmentWidth, 1), output));
        }

        int innerPixelHeight = pixelHeight - (pixelHeight / 10);
        int innerStart = pixelHeight / 20;
        int innerStop = innerStart + innerPixelHeight;
        for (int pixelY = innerStart; pixelY < innerStop; pixelY++)
        {
            double theta = (((pixelY - innerStart) / (double)innerPixelHeight) * pi) / 2.0;
            double sliceRadius = MathHelper.Cos(theta) * radius;
            double sliceCircumfrence = 2.0 * pi * sliceRadius;
            double segmentWidth = sliceCircumfrence / numberOfSegments;
            int pixelSegmentWidth = MathHelper.RoundToInt(segmentWidth * pixelsPerInch * 0.9f);
            graphics.FillRectangle(whiteBrush, FlipYAxis(new Rectangle((pixelWidth - pixelSegmentWidth) / 2, pixelY, pixelSegmentWidth, 1), output));
        }

        graphics.Dispose();
        return output;
    }
    // Scales a rect along the Y axis to account for top to bottom rendering.
    private static Rectangle FlipYAxis(Rectangle rect, Bitmap bitmap)
    {
        return new Rectangle(rect.X, bitmap.Height - (rect.Y + rect.Height), rect.Width, rect.Height);
    }
    // Rounds a float rect to a normal pixel rect.
    private static Rectangle RoundToPixelGrid(RectangleF rect)
    {
        return new Rectangle(MathHelper.RoundToInt(rect.X), MathHelper.RoundToInt(rect.Y), MathHelper.RoundToInt(rect.Width), MathHelper.RoundToInt(rect.Height));
    }
    // Scales a rectangle from inches space to pixel space.
    private static RectangleF ScaleInchesToPixels(RectangleF rect, Bitmap bitmap)
    {
        float dpiX = bitmap.HorizontalResolution;
        float dpiY = bitmap.VerticalResolution;
        RectangleF output = new RectangleF(rect.X * dpiX, rect.Y * dpiY, rect.Width * dpiX, rect.Height * dpiY);
        return output;
    }
}