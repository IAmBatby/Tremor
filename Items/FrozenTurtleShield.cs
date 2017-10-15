using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class FrozenTurtleShield : ModItem
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
			DisplayName.SetDefault("Frozen Turtle Shield");
			Tooltip.SetDefault("The less health, the more defense\n" +
"Grants 25% damage reduction");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			if (player.statLife < 25)
			{
				player.statDefense += 10;
			}
			if (player.statLife < 50)
			{
				player.AddBuff(BuffID.IceBarrier, 2);
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
			recipe.AddIngredient(ItemID.FrozenTurtleShell, 1);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
