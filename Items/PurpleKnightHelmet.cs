using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
[AutoloadEquip(EquipType.Head)]
	public class PurpleKnightHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 22;
			item.value = 10000;
			item.rare = 2;
			item.vanity = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Purple Knight Helmet");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "GrayKnightHelmet", 3);
        recipe.AddIngredient(ItemID.Amethyst, 1);
        recipe.SetResult(this);
        recipe.AddTile(16);
        recipe.AddRecipe();
    }
	}
}
