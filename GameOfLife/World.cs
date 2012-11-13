using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class World
    {
        private List<bool> data;

        public int Width { get; private set; }
        public int Height { get; private set; }


        public World(int width, int height)
        {
            data = new List<bool>(width * height);
            for (var i = 0; i < width * height; i++)
                data.Add(false);

            Width = width;
            Height = height;
        }

        public void Set(int x, int y, bool value)
        {
            x -= OffsetX;
            y -= OffsetY;
            data[y * Width + x] = value;
        }

        public bool Get(int x, int y)
        {
            x -= OffsetX;
            y -= OffsetY;
            if (x < 0 || y < 0 || x >= Width || y >= Height)
                return false;
            return data[y*Width + x];
        }

        public void Grow(bool up, bool left, bool right, bool down)
        {
            var width = Width;
            
            if (left) width++;
            if (right) width++;

            var height = Height;
            
            if (up) height++;
            if (down) height++;
            
            if (left) OffsetX--;
            if (up) OffsetY--;

            while (width * height > data.Count)
            {
                data.Add(false);
            }
            this.Width = width;
            this.Height = height;
        }

        public int OffsetX { get; set; }
        public int OffsetY { get; set; }

        public int EndX()
        {
            return Width + OffsetX;
        }
        public int EndY()
        {
            return Height + OffsetY;
        }

        public void Clear()
        {
            for (var i=0; i<data.Count; i++)
            {
                data[i] = false;
            }
        }

        public void Random()
        {
            var r = new Random();
            for (var i = 0; i<data.Count; i++)
            {
                data[i] = ((r.Next()%3) == 0);
            }
        }


        public int GetNext(int x, int y)
        {
            int n = 0;
            for (int i=x-1; i<=x+1; i++)
                for (int j=y-1; j<=y+1; j++)
                {
                    if (i == x && j == y) continue;
                    if (Get(i, j))
                        n++;
                }

            return n;
        }

        public void GrowToSize(World other)
        {
            while (other.OffsetX < OffsetX)
                Grow(false, true, false, false);

            while (other.OffsetY < OffsetY)
                Grow(true, false, false, false);

            while(other.Width > Width)
                Grow(false, false, true, false);

            while(other.Height > Height)
                Grow(false, false, false, true);
                
        }

    }
}
