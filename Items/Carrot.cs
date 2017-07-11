using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Carrot : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 15;
			item.ranged = true;
			item.width = 22;
			item.height = 22;
			item.maxStack = 999;

			item.consumable = true;
			item.knockBack = 1.5f;
			item.rare = 0;
			item.shoot = mod.ProjectileType("Carrot");
			item.ammo = item.type;
                        item.value = 15;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Carrot");
      Tooltip.SetDefault("");
    }

	}
}
