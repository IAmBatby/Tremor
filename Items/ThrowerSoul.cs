using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class ThrowerSoul : ModItem
{

    public override void SetDefaults()
    {

        item.width = 22;
        item.height = 22;


        item.rare = 3;
        item.accessory = true;
        item.value = 50000;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Thrower Soul");
      Tooltip.SetDefault("10% increased thrown damage\nIncreases thrown critical strike chance by 15");
	  Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 6));
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.1f;
            player.thrownCrit += 15;
        }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "ThrowerFocus");
        recipe.AddIngredient(null, "Opal", 3);
        recipe.AddIngredient(null, "ThrowerEmblem", 1);
        recipe.SetResult(this);
        recipe.AddTile(null, "AltarofEnchantmentsTile");
        recipe.AddRecipe();
    }
}}
