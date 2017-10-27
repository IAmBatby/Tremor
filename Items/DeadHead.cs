using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DeadHead : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 20;
			item.value = 110;
			item.rare = 4;
			item.defense = 5;

			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dead Head");
			Tooltip.SetDefault("4% increased damage and critical strike chance\n" +
"15% increased movement speed");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeDamage += 0.04f;
			player.meleeCrit += 4;

			player.magicDamage += 0.04f;
			player.magicCrit += 4;

			player.rangedDamage += 0.04f;
			player.rangedCrit += 4;

			player.thrownDamage += 0.04f;
			player.thrownCrit += 4;

			player.minionDamage += 0.04f;

			player.moveSpeed += 0.15f;
			player.maxRunSpeed += 0.15f;

			MPlayer modPlayer = Main.LocalPlayer.GetModPlayer<MPlayer>(mod);
			modPlayer.alchemicalDamage += 0.04f;
			modPlayer.alchemicalCrit += 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TheBrain", 1);
			recipe.AddIngredient(null, "AtisBlood", 15);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddIngredient(null, "UntreatedFlesh", 25);
			recipe.AddIngredient(null, "SharpenedTooth", 6);
			recipe.AddIngredient(ItemID.Lens, 2);
			recipe.SetResult(this);
			recipe.AddTile(null, "FleshWorkstationTile");
			recipe.AddRecipe();
		}
	}
}
