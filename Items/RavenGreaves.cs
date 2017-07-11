using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Legs)]
public class RavenGreaves : ModItem
{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 10000;


			item.rare = 4;
                        item.defense = 9;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Raven Greaves");
      Tooltip.SetDefault("5% increased melee damage\nIncreases melee critical strike chance by 5");
    }


    public override void UpdateEquip(Player player)
    {
            player.meleeDamage += 0.05f;
            player.meleeCrit += 5;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.MoltenGreaves);
        recipe.AddIngredient(ItemID.IronBar, 7);
        recipe.AddIngredient(null, "RavenFeather", 10);
        recipe.SetResult(this);
        recipe.AddTile(16);
        recipe.AddRecipe();

        recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.MoltenGreaves);
        recipe.AddIngredient(ItemID.LeadBar, 7);
        recipe.AddIngredient(null, "RavenFeather", 10);
        recipe.SetResult(this);
        recipe.AddTile(16);
        recipe.AddRecipe();
    }

}}
