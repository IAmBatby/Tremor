using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class StarfallTome : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 25;
        item.melee = false;
        item.magic = true;
        item.width = 50;
        item.height = 55;
        item.useTime = 30;
        item.mana = 20;
        item.useAnimation = 30;
        item.useStyle = 5;
	item.shoot = 9;
        item.shootSpeed = 30f; 
        item.knockBack = 3;
        item.value = 30000;
        item.rare = 3;
        item.UseSound = SoundID.Item4;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Starfall Tome");
      Tooltip.SetDefault("");
    }

}
}
