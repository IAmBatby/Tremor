using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class NightingaleChestplate : ModItem
	{
		public override void SetDefaults()
		{

			item.defense = 7;
			item.width = 22;
			item.height = 30;
			item.value = 3025;
			item.rare = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightingale Chestplate");
			Tooltip.SetDefault("5% increased damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.05f;
			player.thrownDamage += 0.05f;
			player.rangedDamage += 0.05f;
			player.magicDamage += 0.05f;
			player.minionDamage += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SteelBar", 15);
			recipe.AddIngredient(null, "PhantomSoul", 4);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
