using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PeachFox
{
    using Images = Dictionary<int, Bitmap>;

    public static class TileButtonDataHelper
    {
        public static void Set(this Images dict, int key, Bitmap image)
        {
            if (dict.ContainsKey(key))
                dict[key] = image;
            else
                dict.Add(key, image);
        }
    }

    class TileButtonData
    {
        public Images Background = new Images();
        public Images Foreground = new Images();
        public bool IsHovered = false;

        public void Clean()
        {
            Background = new Images();
            Foreground = new Images();
        }
    }
}
