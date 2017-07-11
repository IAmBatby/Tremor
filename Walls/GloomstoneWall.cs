using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Walls
{
	public class GloomstoneWall : ModWall
{
    public override void SetDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = mod.ItemType("GloomstoneWall");
	AddMapEntry(new Color(10, 63, 98));
    }
}}