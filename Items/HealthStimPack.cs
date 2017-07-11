using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class HealthStimPack : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 36;
			item.maxStack = 999;
			item.rare = 11;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Health Stim Pack");
			Tooltip.SetDefault("Restores 50 health\nHas no cooldown");
		}

		public override bool UseItem(Player player)
		{
			Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 3);
			Main.player[Main.myPlayer].HealEffect(50);
			player.statLife += 50;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrassBar", 2);
			recipe.AddIngredient(ItemID.SuperHealingPotion);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(null, "NightmareBar", 5);
			recipe.SetResult(this);
			recipe.AddTile(13);
			recipe.AddRecipe();
		}

	}
}