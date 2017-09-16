using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RoboticDeadHead : ModItem
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
			Tooltip.SetDefault("15% increased damage\n12% increased critical strike chance\n25% increased movement speed");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeDamage += 0.15f;
			player.meleeCrit += 12;

			player.magicDamage += 0.15f;
			player.magicCrit += 12;

			player.rangedDamage += 0.15f;
			player.rangedCrit += 12;
			
			player.thrownDamage += 0.15f;
			player.thrownCrit += 12;

			player.minionDamage += 0.15f;

			player.moveSpeed += 0.25f;
			player.maxRunSpeed += 0.25f;

			MPlayer modPlayer = Main.LocalPlayer.GetModPlayer<MPlayer>(mod);
			modPlayer.alchemicalDamage += 0.15f;
			modPlayer.alchemicalCrit += 12;
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
