using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class RockClimberPotion : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 32;
			item.maxStack = 20;

			item.rare = 1;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rock Climber Potion");
			Tooltip.SetDefault("Grants ability to climb walls");
		}


		public override bool UseItem(Player player)
		{
			player.AddBuff(mod.BuffType("RockClimberBuff"), 3600);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ItemID.StoneBlock, 15);
			recipe.AddIngredient(ItemID.Blinkroot, 1);
			recipe.AddTile(13);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
