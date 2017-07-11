using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
[AutoloadEquip(EquipType.Wings)]
	public class ColdMetalWings : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 20;

			item.value = 125000;
			item.rare = 11;
			item.accessory = true;

		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Frosteel Wings");
      Tooltip.SetDefault("Allows flight and slow fall");
    }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.wingTimeMax = 200;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{

            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.155f;
        }

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
            speed = 15f;
            acceleration *= 2.5f;
        }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "FrostoneBar", 5);
        recipe.AddIngredient(null, "IceSoul", 5);
        recipe.AddIngredient(ItemID.SoulofFlight, 20);
        recipe.SetResult(this);
	recipe.AddTile(134);
        recipe.AddRecipe();
    }
		
	}
}
