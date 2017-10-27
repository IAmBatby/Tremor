using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TrueBeamSword : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 92;
			item.melee = true;
			item.width = 50;
			item.height = 52;
			item.useTime = 45;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.shoot = 116;
			item.shootSpeed = 15f;
			item.knockBack = 8;

			item.value = 750000;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Beam Sword");
			Tooltip.SetDefault("Shoots a beam of light");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EnchantedSword, 1);
			recipe.AddIngredient(ItemID.BeamSword, 1);
			recipe.AddIngredient(null, "MagiumShard", 25);
			recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
