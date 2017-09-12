using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DeathFormula : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 30000;
			item.rare = 3;
			item.maxStack = 1;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Death Formula");
			Tooltip.SetDefault("20% increased alchemical critical strike chance");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 20;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(null, "GelCube", 25);
			recipe.AddIngredient(null, "CursedSoul", 1);
			recipe.AddIngredient(null, "TearsofDeath", 15);
			recipe.SetResult(this);
			recipe.AddTile(13);
			recipe.AddRecipe();
		}
	}
}
