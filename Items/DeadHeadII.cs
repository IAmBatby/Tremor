using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DeadHeadII : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 20;
			item.value = 110;
			item.rare = 4;
			item.defense = 10;

			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Robotic Dead Head");
			Tooltip.SetDefault("Increases all stats");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.meleeDamage += 0.15f;
			player.meleeCrit += 12;
			player.magicDamage += 0.15f;
			player.magicCrit += 12;
			player.rangedDamage += 0.15f;
			player.rangedCrit += 12;
			player.minionDamage += 0.15f;
			player.thrownDamage += 0.15f;
			player.moveSpeed += 0.25f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DeadHead", 1);
			recipe.AddIngredient(null, "CarbonSteel", 15);
			recipe.AddIngredient(null, "Doomstone", 5);
			recipe.AddIngredient(null, "DeadTissue", 5);
			recipe.AddIngredient(null, "Phantaplasm", 8);
			recipe.AddIngredient(null, "EyeofOblivion", 2);
			recipe.SetResult(this);
			recipe.AddTile(null, "AlchemyStationTile");
			recipe.AddRecipe();
		}
	}
}
