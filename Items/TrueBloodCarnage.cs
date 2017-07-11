using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TrueBloodCarnage : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 92;
			item.melee = true;
			item.width = 50;
			item.height = 52;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.shoot = mod.ProjectileType("TrueBloodCarnage");
			item.shootSpeed = 10f;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Blood Carnage");
			Tooltip.SetDefault("");
		}



		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 60);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BloodCarnage", 1);
			recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
