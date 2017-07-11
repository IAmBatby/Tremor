using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { 
[AutoloadEquip(EquipType.Body)]
public class DragonBreastplate : ModItem
{
    public override void SetDefaults()
    {

        item.width = 30;
        item.height = 26;


        item.value = 35000;
        item.rare = 11;
        item.defense = 29;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Dragon Breastplate");
      Tooltip.SetDefault("50% increased ranged damage\nIncreased ranged critical strike chance by 34");
    }


		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.5f;
                        player.rangedCrit += 34;
		}

public virtual void ArmorSetShadows(Player player, ref bool longTrail, ref bool smallPulse, ref bool largePulse, ref bool shortTrail)
{
longTrail = true;
}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DragonCapsule", 12);
			recipe.AddIngredient(null, "EarthFragment", 10);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}    
}}
