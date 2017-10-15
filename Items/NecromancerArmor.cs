using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NecromancerArmor : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 34;
			item.height = 34;
			item.value = 150000;
			item.rare = 3;
			item.defense = 10;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Necromancer Armor");
			Tooltip.SetDefault("18% increased minion damage\n" +
"20% increased minion knockback");
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.18f;
			player.minionKB += 0.2f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "HardArmor", 1);
			recipe.AddIngredient(null, "TikiArmor", 1);
			recipe.AddIngredient(null, "NecromancerBelt", 1);
			recipe.AddIngredient(ItemID.SoulofNight, 25);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}
