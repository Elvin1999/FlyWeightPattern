using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    interface IImage
    {
        string GetPath();
        int GetHeight();
        int GetWidth();
    }
    class PngImage : IImage
    {
        public PngImage(string path)
        {
            Height = 100;
            Width = 100;
            Path = path;
        }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Path { get; set; }
        public int GetHeight()
        {
            return Height;
        }

        public string GetPath()
        {
            return Path;
        }

        public int GetWidth()
        {
            return Width;
        }
    }
    class GifImage : IImage
    {
        public GifImage(string path)
        {
            Height = 100;
            Width = 100;
            Path = path;
        }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Path { get; set; }
        public int GetHeight()
        {
            return Height;
        }

        public string GetPath()
        {
            return Path;
        }

        public int GetWidth()
        {
            return Width;
        }
    }

    class ImageFactory
    {
        public IImage GetImage(string path)
        {
            var item = images.SingleOrDefault(x => x.GetPath() == path);
            if (item == null)
            {
                if (path.Contains(".png"))
                {
                    item = new PngImage(path);
                }
                else if (path.Contains(".gif"))
                {
                    item = new GifImage(path);
                }
                images.Add(item);
            }
            return item;
        }
        public void AddImage(IImage image)
        {
            images.Add(image);
        }
        List<IImage> images = new List<IImage>();

    }
    class Program
    {
        static void Main(string[] args)
        {

            ImageFactory image = new ImageFactory();

            PngImage pngImage = image.GetImage(@"C:\user\p.png") as PngImage;
            PngImage npng = image.GetImage(@"C:\user\p.png") as PngImage;
            PngImage npng2 = image.GetImage(@"C:\user\pppp.png") as PngImage;
            GifImage gifImage = image.GetImage(@"C:\user\123g.gif") as GifImage;
            Console.WriteLine(pngImage.GetHashCode());
            Console.WriteLine(npng.GetHashCode());
            Console.WriteLine(npng2.GetHashCode());
            Console.WriteLine(gifImage.GetHashCode());
            GifImage gifImage2 = image.GetImage(@"C:\user\123g.gif") as GifImage;
            Console.WriteLine(gifImage2.GetHashCode());
            GifImage gifImage3 = image.GetImage(@"C:\user\1234g.gif") as GifImage;
            Console.WriteLine(gifImage3.GetHashCode());
        }
    }
}
