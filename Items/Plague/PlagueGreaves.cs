using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Plague
{
	[AutoloadEquip(EquipType.Legs)]
	public class PlagueGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 25000;
			item.rare = 2;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plague Greaves");
			Tooltip.SetDefault("10% increased alchemical damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 16);
			recipe.AddIngredient(null, "PhantomSoul", 4);
			recipe.AddIngredient(null, "TearsofDeath", 8);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}

	}
}
