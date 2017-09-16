using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class DragonShield : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 34;
			item.height = 36;
			item.value = 32000;
			item.rare = 11;
			item.accessory = true;
			item.defense = 24;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Shield");
			Tooltip.SetDefault("Allows to dash\nDouble tap a direction\n60% increased movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.dash = 1;
			player.moveSpeed += 0.6f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DragonCapsule", 14);
			recipe.AddIngredient(null, "EarthFragment", 8);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
