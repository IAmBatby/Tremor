using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Dark
{
	[AutoloadEquip(EquipType.Shield)]
	public class DarkAbsorber : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;

			item.value = 45000;
			item.rare = 5;
			item.accessory = true;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Absorber");
			Tooltip.SetDefault("Gives health when in Corruption");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneCorrupt)
			{
				player.statLifeMax2 += 100;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 28);
			recipe.AddIngredient(ItemID.ShadowScale, 45);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
