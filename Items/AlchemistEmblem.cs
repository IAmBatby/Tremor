using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AlchemistEmblem : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 28;
			item.value = 20000;
			item.rare = 4;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Emblem");
			Tooltip.SetDefault("15% increased alchemic damage");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.15f;
		}

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.AvengerEmblem);
			recipe.AddRecipe();
		}
	}
}
