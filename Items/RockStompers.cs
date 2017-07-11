using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RockStompers : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 20;
			item.value = 110000;
			item.rare = 3;

			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rock Stompers");
			Tooltip.SetDefault("Increases your knockback effect");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.kbBuff = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 25);
			recipe.AddIngredient(ItemID.Leather, 10);
			recipe.AddIngredient(null, "RockHorn", 10);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
