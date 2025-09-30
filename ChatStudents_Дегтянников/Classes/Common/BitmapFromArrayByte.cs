using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ChatStudents_Дегтянников.Classes.Common
{
    public class BitmapFromArrayByte
    {
        public static BitmapImage LoadImage(byte[] imagedata)
        {
            BitmapImage Image = new BitmapImage();
            using(var Stream = new MemoryStream(imagedata))
            {
                Stream.Position = 0;
                Image.BeginInit();
                Image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                Image.CacheOption = BitmapCacheOption.OnLoad;
                Image.UriSource = null;
                Image.StreamSource = Stream;
                Image.EndInit();
            }
            Image.Freeze();
            return Image;
        }
    }
}
