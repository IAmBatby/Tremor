using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FrostsparkStompers : ModItem
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
			DisplayName.SetDefault("Frostspark Stompers");
			Tooltip.SetDefault("10% increased movement speed and increases knockback effect\n" +
"Allows flight, super fast running, and extra mobility on ice");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.accRunSpeed = 6.75f;
			player.rocketBoots = 3;
			player.moveSpeed += 0.1f;
			player.maxRunSpeed += 0.1f;
			player.kbBuff = true;
			player.iceSkate = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1862, 1);
			recipe.AddIngredient(null, "RockStompers", 1);
			recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.AddRecipe();
		}
	}
}
