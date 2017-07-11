using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DivineForge : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 50;
			item.height = 26;
			item.maxStack = 99;
			item.useTurn = true;
			item.rare = 11;
			item.autoReuse = true;
			item.useAnimation = 15;


			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("DivineForgeTile");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Divine Forge");
			Tooltip.SetDefault("Combines the function of the anvil, furnace and the ancient manipulator\nAllows you to work with heavenly materials");
		}


		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CollapsiumOre", 30);
			recipe.AddIngredient(null, "AngeliteOre", 30);
			recipe.AddIngredient(null, "OmnikronBar", 5);
			recipe.AddIngredient(ItemID.MythrilAnvil, 1);
			recipe.AddIngredient(ItemID.AdamantiteForge, 1);
			recipe.AddIngredient(null, "TrueEssense", 10);
			recipe.AddIngredient(3549, 1);
			recipe.AddTile(null, "StarvilTile");
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CollapsiumOre", 30);
			recipe.AddIngredient(null, "AngeliteOre", 30);
			recipe.AddIngredient(null, "OmnikronBar", 5);
			recipe.AddIngredient(ItemID.OrichalcumAnvil, 1);
			recipe.AddIngredient(ItemID.AdamantiteForge, 1);
			recipe.AddIngredient(null, "TrueEssense", 10);
			recipe.AddIngredient(3549, 1);
			recipe.AddTile(null, "StarvilTile");
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CollapsiumOre", 30);
			recipe.AddIngredient(null, "AngeliteOre", 30);
			recipe.AddIngredient(null, "OmnikronBar", 5);
			recipe.AddIngredient(ItemID.OrichalcumAnvil, 1);
			recipe.AddIngredient(ItemID.TitaniumForge, 1);
			recipe.AddIngredient(null, "TrueEssense", 10);
			recipe.AddIngredient(3549, 1);
			recipe.AddTile(null, "StarvilTile");
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CollapsiumOre", 30);
			recipe.AddIngredient(null, "AngeliteOre", 30);
			recipe.AddIngredient(null, "OmnikronBar", 5);
			recipe.AddIngredient(ItemID.MythrilAnvil, 1);
			recipe.AddIngredient(ItemID.TitaniumForge, 1);
			recipe.AddIngredient(null, "TrueEssense", 10);
			recipe.AddIngredient(3549, 1);
			recipe.AddTile(null, "StarvilTile");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
