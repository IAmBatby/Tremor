using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PhilosophersFlower : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 44;
			item.value = 100;
			item.rare = 4;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Philosophers Flower");
			Tooltip.SetDefault("Reduces the cooldown of healing potions\n" +
"Automatically uses mana potions when needed");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.potionDelayTime = 2700;
			player.manaFlower = true;
			player.manaCost -= 0.10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PhilosophersStone, 1);
			recipe.AddIngredient(ItemID.ManaFlower, 1);
			recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.AddRecipe();
		}
	}
}
