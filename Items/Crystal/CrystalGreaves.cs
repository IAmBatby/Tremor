using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Crystal
{
	[AutoloadEquip(EquipType.Legs)]
	public class CrystalGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.defense = 5;
			item.width = 22;
			item.height = 18;
			item.value = 2500;
			item.rare = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Greaves");
			Tooltip.SetDefault("20% increased throwing critical strike chance");
		}

		public override void UpdateEquip(Player p)
		{
			p.thrownCrit += 20;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalShard, 25);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
