using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Crystal
{
	[AutoloadEquip(EquipType.Body)]
	public class CrystalChestplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;

			item.value = 200;
			item.rare = 4;
			item.defense = 9;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Chestplate");
			Tooltip.SetDefault("30% increased throwing velocity");
		}

		public override void UpdateEquip(Player p)
		{
			p.thrownVelocity += 0.3f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalShard, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
