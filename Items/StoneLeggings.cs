using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class StoneLeggings : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 0;

			item.rare = 1;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Leggings");
			Tooltip.SetDefault("4% increased melee damage");
		}


		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.04f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 50);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
