using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.MagicalArmor
{
	[AutoloadEquip(EquipType.Body)]
	public class MagicalRobe : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 250;

			item.height = 28;
			item.value = 600;
			item.rare = 1;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Theurgic Mantle");
			Tooltip.SetDefault("4% increased magic damage\n" +
"Increases maximum mana by 20");
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.04f;
			player.statManaMax2 += 20;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 14);
			recipe.AddIngredient(ItemID.LeadBar, 6);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 14);
			recipe.AddIngredient(ItemID.IronBar, 6);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}

	}
}
