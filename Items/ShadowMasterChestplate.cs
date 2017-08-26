using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class ShadowMasterChestplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;


			item.value = 10000;
			item.rare = 11;
			item.defense = 25;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Master Chestplate");
			Tooltip.SetDefault("Increases alchemic damage by 25%\nIncreases throwing damage by 15%");
		}


		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.25f;
			player.thrownDamage += 0.15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrokenHeroArmorplate", 1);
			recipe.AddIngredient(ItemID.Silk, 15);
			recipe.AddIngredient(null, "SoulofFight", 10);
			recipe.AddIngredient(null, "DarkGel", 15);
			recipe.AddIngredient(null, "DarknessCloth", 8);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
