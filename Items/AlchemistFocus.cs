using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class AlchemistFocus : ModItem
{

    public override void SetDefaults()
    {

        item.width = 22;
        item.height = 22;


        item.rare = 2;
        item.accessory = true;
        item.value = 50000;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Alchemist Focus");
      Tooltip.SetDefault("6% increased alchemic damage\nIncreases alchemic critical strike chance by 12");
	  Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
        {
        player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.06f;
	player.GetModPlayer<MPlayer>(mod).alchemistCrit += 12;
        }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "AlchemistSpark");
        recipe.AddIngredient(null, "GelCube", 25);
        recipe.AddIngredient(ItemID.Amethyst, 16);
        recipe.SetResult(this);
        recipe.AddTile(null, "AltarofEnchantmentsTile");
        recipe.AddRecipe();
    }
}}
