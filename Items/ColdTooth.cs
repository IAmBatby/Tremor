using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Tremor.Items
{
	public class ColdTooth : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.melee = true;
			item.width = 42;
			item.height = 46;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = 309;
			item.shootSpeed = 6f;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 46000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cold Tooth");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldBroadsword, 1);
			recipe.AddIngredient(null, "FrostCore", 8);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBroadsword, 1);
			recipe.AddIngredient(null, "FrostCore", 8);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(44, 60);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(1) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 80);
			}
		}
	}
}
