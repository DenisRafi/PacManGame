using System;
using System.Collections.Generic;

namespace ByDR
{
    class SmartGhost : Object
    {       
        public SmartGhost(int x, int y, direction Direction)
        {
            this.X = x;
            this.Y = y;
            currentStatePlace = _.map.Jewel;
            objectDirection = Direction;
            _.map.RenderChar(x, y, GetSymbol());
        }

        public override char GetSymbol()
        {
            return Map.smartGhostSymbol;
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

            Pacman pacman = _.pacman;

            if (x < pacman.x && objectDirection != direction.left && variantsOfDirection.Contains(direction.right))
            {
                objectDirection = direction.right;
            }
            else if (x > pacman.x && objectDirection != direction.right && variantsOfDirection.Contains(direction.left))
            {
                objectDirection = direction.left;
            }
            else if (y > pacman.y && objectDirection != direction.down && variantsOfDirection.Contains(direction.up))
            {
                objectDirection = direction.up;
            }
            else if (y < pacman.y && objectDirection != direction.up && variantsOfDirection.Contains(direction.down))
            {
                objectDirection = direction.down;
            }
            else
            {
                Random random = new Random();
                int index = random.Next(variantsOfDirection.Count);
                objectDirection = variantsOfDirection[index];
            }
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