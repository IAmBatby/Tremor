using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Tremor.Items
{ 
[AutoloadEquip(EquipType.Body)]
    public class TrueHeroShirt : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 18;

            item.value = 25000;
            item.rare = 0;
            item.defense = 25;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("True Hero Shirt");
      Tooltip.SetDefault("Gives one of three true blades");
    }


        public override void UpdateEquip(Player player)
        {
            player.AddBuff(mod.BuffType("SecondTrueBlade"), 2);
        }

	public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
        {
            tooltips[0].overrideColor = new Color(238, 194, 73);
        }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(248, 1);
        recipe.AddIngredient(null, "GiantShell", 1);
        recipe.AddIngredient(null, "BrokenHeroArmorplate", 1);
        recipe.AddIngredient(null, "TrueEssense", 3);
        recipe.SetResult(this);
	recipe.AddTile(412);
        recipe.AddRecipe();
    }
    }
}
