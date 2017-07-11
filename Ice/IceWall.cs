using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice {
public class IceWall : ModWall
{
    public override void SetDefaults()
    {
            Main.wallHouse[Type] = false;
            dustType = 80;
            soundType = 21;
            soundStyle = 2;
            AddMapEntry(new Color(50, 123, 179));
        }

        public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i - 1, j].wall > 0 && CanGrow(i - 1, j))
            {
                Main.tile[i - 1, j].wall = (ushort)mod.WallType("IceWall");
            }

            if (Main.tile[i + 1, j].wall > 0 && CanGrow(i + 1, j))
            {
                Main.tile[i + 1, j].wall = (ushort)mod.WallType("IceWall");
            }

            if (Main.tile[i, j - 1].wall > 0 && CanGrow(i, j - 1))
            {
                Main.tile[i, j - 1].wall = (ushort)mod.WallType("IceWall");
            }

            if (Main.tile[i, j + 1].wall > 0 && CanGrow(i, j + 1))
            {
                Main.tile[i, j + 1].wall = (ushort)mod.WallType("IceWall");
            }
        }

        public bool CanGrow(int i, int j)
        {
            bool flag = false;
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                {
                    if (!Main.tile[i - 1 + x, j - 1 + y].active())
                        flag = true;
                }
            return flag;
        }
    }
}