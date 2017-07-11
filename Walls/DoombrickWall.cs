using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Walls
{
	public class DoombrickWall : ModWall
{
    public override void SetDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = mod.ItemType("DoombrickWall");
	AddMapEntry(new Color(233, 255, 0));
    }
}}