using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class TurtleShield : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 36;
			item.height = 42;
			item.value = 123450;
			item.rare = 8;

			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Turtle Shield");
			Tooltip.SetDefault("The less health, the more defense...");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
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
			recipe.AddIngredient(ItemID.ChlorophyteBar, 20);
			recipe.AddIngredient(ItemID.TurtleShell, 2);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
