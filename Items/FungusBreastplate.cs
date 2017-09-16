using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class FungusBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 50000;

			item.rare = 3;
			item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungus Breastplate");
			Tooltip.SetDefault("13% increased all damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.13f;
			player.magicDamage += 0.13f;
			player.rangedDamage += 0.13f;
			player.thrownDamage += 0.13f;
			player.minionDamage += 0.13f;
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.13f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FungusElement", 18);
			recipe.AddIngredient(ItemID.GlowingMushroom, 15);
			recipe.AddIngredient(ItemID.GoldChainmail, 1);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FungusElement", 18);
			recipe.AddIngredient(ItemID.GlowingMushroom, 15);
			recipe.AddIngredient(ItemID.PlatinumChainmail, 1);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
