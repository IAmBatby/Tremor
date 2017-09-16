using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class EnchantedManaBooster : ModItem
	{
		public override void SetDefaults()
		{

			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 4;
			item.width = 22;
			item.UseSound = SoundID.Item43;
			item.height = 18;
			item.buffType = mod.BuffType("ExtendedManaBooster");
			item.value = 5160000;
			item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Mana Booster");
			Tooltip.SetDefault("Regenerates mana every 45 seconds");
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 2700, true);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ManaBooster", 1);
			recipe.AddIngredient(null, "GoldenClaw", 15);
			recipe.AddIngredient(null, "StarBar", 1);
			recipe.AddIngredient(null, "AngryShard", 1);
			recipe.SetResult(this);
			recipe.AddTile(null, "MagicWorkbenchTile");
			recipe.AddRecipe();
		}
	}
}
