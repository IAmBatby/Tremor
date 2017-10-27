using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class BeetleShield : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 24;
			item.value = 123110;
			item.rare = 8;

			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beetle Shield");
			Tooltip.SetDefault("The less health, the more defense\n" +
"Maximum life increased by 50");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.statLifeMax2 += 50;
			if (player.statLife < 25)
			{
				player.statDefense += 10;
			}
			if (player.statLife < 100)
			{
				player.statDefense += 8;
			}
			if (player.statLife < 200)
			{
				player.statDefense += 6;
			}
			if (player.statLife < 300)
			{
				player.statDefense += 3;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TurtleShield", 1);
			recipe.AddIngredient(null, "LeechingSeed", 1);
			recipe.AddIngredient(ItemID.BeetleHusk, 10);
			recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.AddRecipe();
		}
	}
}
