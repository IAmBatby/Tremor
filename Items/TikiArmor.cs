using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class TikiArmor : ModItem
{

    public override void SetDefaults()
    {

        item.width = 34;
        item.height = 34;
        item.value = 150000;
        item.rare = 3;

        item.defense = 4;
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Tiki Armor");
      Tooltip.SetDefault("15% increased minion damage");
    }


    public override void UpdateEquip(Player player)
    {
            player.minionDamage += 0.15f;
    }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "JungleAlloy", 1);
			recipe.AddIngredient(null, "WoodenFrame", 1);
            recipe.AddIngredient(ItemID.Vine, 5);
            recipe.AddIngredient(ItemID.JungleSpores, 15);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}   

}}
