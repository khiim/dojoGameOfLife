using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Processor
    {

        private World[] world = new World[2];

        private int current = 0;
        private int next = 1;

        public World CurrentWorld { get { return world[current];  } }

        public Processor(World world1, World world2)
        {
            world[0] = world1;
            world[1] = world2;
        }


        public void Tick()
        {
            world[next].Clear();
            world[next].GrowToSize(CurrentWorld);

            var minX = world[next].OffsetX;
            var maxX = world[next].EndX();
            var minY = world[next].OffsetY;
            var maxY = world[next].EndY();

            bool growUp = false;
            bool growLeft = false;
            bool growRight = false;
            bool growDown = false;

            for (var x = minX; x < maxX; x++)
            {
                if (CurrentWorld.Get(x, CurrentWorld.OffsetY))
                    growUp = true;
                

                if (CurrentWorld.Get(x, CurrentWorld.EndY() - 1))
                    growDown = true;
            }

            for (var y = minY; y < maxY; y++)
            {
                if (CurrentWorld.Get(CurrentWorld.OffsetX, y))
                    growLeft = true;


                if (CurrentWorld.Get(CurrentWorld.EndX() - 1, y))
                    growRight = true;
            }

            world[next].Grow(growUp, growLeft, growRight, growDown);

            for (var x = minX; x < maxX; x++)
                {
                    for (var y = minY; y < maxY; y++)
                    {
                        var s = world[current].Get(x, y);
                        var n = world[current].GetNext(x, y);

                        if (s)
                        {
                            world[next].Set(x, y, (n == 2 || n == 3));

                        }
                        else
                        {
                            world[next].Set(x, y, (n == 3));
                        }
                    }
                }

            current += 1;
            current %= 2;

            next += 1;
            next %= 2;

        }

    }
}
