using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class AlchemistSoul : ModItem
{

    public override void SetDefaults()
    {

        item.width = 22;
        item.height = 22;


        item.rare = 3;
        item.accessory = true;
        item.value = 100000;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Alchemist Soul");
      Tooltip.SetDefault("12% increased alchemic damage\nIncreases alchemic critical strike chance by 15");
	  Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 6));
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
        {
        player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.12f;
	player.GetModPlayer<MPlayer>(mod).alchemistCrit += 15;
        }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "AlchemistFocus");
        recipe.AddIngredient(null, "Opal", 3);
        recipe.AddIngredient(null, "AlchemistEmblem", 1);
        recipe.SetResult(this);
        recipe.AddTile(null, "AltarofEnchantmentsTile");
        recipe.AddRecipe();
    }
}}
