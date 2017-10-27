using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NecromancerBelt : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.value = 30000;
			item.rare = 2;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Necromancer Belt");
			Tooltip.SetDefault("Increases minion knockback by 20%\n" +
"Increases your maximum number of minions");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.minionKB += 0.2f;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "StrongBelt");
			recipe.AddIngredient(1158, 1);
			recipe.AddIngredient(null, "UntreatedFlesh", 25);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.AddRecipe();
		}
	}
}
