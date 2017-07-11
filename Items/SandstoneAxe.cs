using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class SandstoneAxe : ModItem
{
    public override void SetDefaults()
    {

				item.autoReuse = true;
				item.useStyle = 1;
				item.useAnimation = 30;
				item.knockBack = 6f;
				item.useTime = 15;
				item.width = 24;
				item.height = 28;
				item.damage = 16;
				item.axe = 15;
				item.scale = 1.2f;
				item.UseSound = SoundID.Item1;
				item.rare = 1;
				item.value = 13500;
				item.melee = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Dune Axe");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "AntlionShell", 1);
        recipe.AddIngredient(ItemID.Topaz, 3);
        recipe.AddIngredient(ItemID.AntlionMandible, 5);
        recipe.AddTile(16);
        recipe.SetResult(this);
        recipe.AddRecipe();
}
}}
