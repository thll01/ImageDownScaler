using System.Drawing;
using System.Threading.Tasks;

public class ImageProperties
{
    public static Bitmap ConsequentialDownscale(Bitmap source, float factor)
    {
        int newWidth = (int)(source.Width * factor);
        int newHeight = (int)(source.Height * factor);

        if (newWidth <= 0 || newHeight <= 0)
        {
            // Handle this case to prevent creating an invalid Bitmap
            return null;
        }

        Bitmap result = new Bitmap(newWidth, newHeight);

        for (int x = 0; x < newWidth; x++)
        {
            for (int y = 0; y < newHeight; y++)
            {
                Color pixel = source.GetPixel((int)(x / factor), (int)(y / factor));
                result.SetPixel(x, y, pixel);
            }
        }

        return result;
    }
    public static Bitmap ParallelDownscale(Bitmap source, float factor)
    {
        int newWidth = (int)(source.Width * factor);
        int newHeight = (int)(source.Height * factor);
        Bitmap result = new Bitmap(newWidth, newHeight);

        Parallel.For(0, newWidth, x =>
        {
            for (int y = 0; y < newHeight; y++)
            {
                Color pixel = source.GetPixel((int)(x / factor), (int)(y / factor));
                result.SetPixel(x, y, pixel);
            }
        });

        return result;
    }
}
