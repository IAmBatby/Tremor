using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
    public class CrystalSpear : ModItem
    {
        public override void SetDefaults()
        {
		    item.CloneDefaults(165);

            item.damage = 49;
            item.magic = true;
            item.width = 26;

            item.height = 30;
            item.useTime = 25;
            item.useAnimation = 25;
            item.shoot = mod.ProjectileType("CrSpear");
            item.shootSpeed = 11.5f; 
            item.useStyle = 5;
            item.knockBack = 4;
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
			item.mana = 12;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Crystal Spear");
      Tooltip.SetDefault("Shoots sharp crystal spears");
    }

	}
}
