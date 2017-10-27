using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Neck)]
	public class SpectreNecklace : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 20;
			item.value = 110;
			item.rare = 8;

			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectre Necklace");
			Tooltip.SetDefault("The less mana, the more defense...");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			if (player.statMana < 25)
			{
				player.statDefense += 10;
			}
			if (player.statMana < 100)
			{
				player.statDefense += 8;
			}
			if (player.statMana < 200)
			{
				player.statDefense += 6;
			}
			if (player.statMana < 300)
			{
				player.statDefense += 3;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpectreBar, 25);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
