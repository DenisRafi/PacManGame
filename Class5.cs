using System;
using System.Collections.Generic;

namespace ByDR
{
    class StupidGhost : Object
    {
        public StupidGhost(int x, int y, direction Direction)
        {
            this.X = x;
            this.Y = y;
            currentStatePlace = _.map.EmptySpace;
            objectDirection = Direction;
            _.map.RenderChar(x, y, GetSymbol());
        }

        public override char GetSymbol()
        {
            return Map.stupidGhostSymbol;
        }

        public void DetectDirection()
        {
            List<direction> variantsOfDirection = new List<direction>();
            if (objectDirection == direction.up)
            {
                if (_.map[x, y - 1] != Map.wall)
                {
                    variantsOfDirection.Add(direction.up);
                }
                if (_.map[x - 1, y] != Map.wall)
                {
                    variantsOfDirection.Add(direction.left);
                }
                if (_.map[x + 1, y] != Map.wall)
                {
                    variantsOfDirection.Add(direction.right);
                }
            }
            else if (objectDirection == direction.down)
            {
                if (_.map[x, y + 1] != Map.wall)
                {
                    variantsOfDirection.Add(direction.down);
                }
                if (_.map[x - 1, y] != Map.wall)
                {
                    variantsOfDirection.Add(direction.left);
                }
                if (_.map[x + 1, y] != Map.wall)
                {
                    variantsOfDirection.Add(direction.right);
                }
            }
            else if (objectDirection == direction.left)
            {
                if (_.map[x, y - 1] != Map.wall)
                {
                    variantsOfDirection.Add(direction.up);
                }
                if (_.map[x - 1, y] != Map.wall)
                {
                    variantsOfDirection.Add(direction.left);
                }
                if (_.map[x, y + 1] != Map.wall)
                {
                    variantsOfDirection.Add(direction.down);
                }
            }
            else
            {
                if (_.map[x, y - 1] != Map.wall)
                {
                    variantsOfDirection.Add(direction.up);
                }
                if (_.map[x, y + 1] != Map.wall)
                {
                    variantsOfDirection.Add(direction.down);
                }
                if (_.map[x + 1, y] != Map.wall)
                {
                    variantsOfDirection.Add(direction.right);
                }
            }
            Random random = new Random();
            int index = random.Next(variantsOfDirection.Count);
            objectDirection = variantsOfDirection[index];
        }
        public override void Step()
        {
            KillPacman();
            DetectDirection();
            ChangePositionByDirection(objectDirection);
            KillPacman();
        }
    }
}