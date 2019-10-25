using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PeachFox
{
    public class TileData
    {
        public Bitmap image;
        public string fullpath;
        public string shortpath;
        public Quad quad;
        public Anim anim;
        public struct Quad
        {
            public int X, Y, W, H;
        }
        public class Anim
        {
            public int X, Y, Num;
        }

        public void Dispose()
        { }
    }

}
