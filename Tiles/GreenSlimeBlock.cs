using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Tiles
{
	public class GreenSlimeBlock : ModTile
{
    public override void SetDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        soundType = 4;
        soundStyle = 1;
        AddMapEntry(new Color(75, 192, 126));
        drop = mod.ItemType("GreenSlimeBlock");
    }
}}