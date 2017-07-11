using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class VoidKnife : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 666;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 120000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.5f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Knife");
			Tooltip.SetDefault("Hitting enemies will spawn an explosion\nIf you are below 50% of life your hits have a chance to heal you");
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("VoidKnifeExplosion"), damage, knockback, Main.myPlayer);
			if (player.statLife < (player.statLifeMax2 * 0.5f) && Main.rand.Next(4) == 0)
			{
				int NewLife = Main.rand.Next(19, 41);
				player.statLife += NewLife;
				player.HealEffect(NewLife);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "VoidBar", 15);
			recipe.AddIngredient(null, "DarkMatter", 64);
			recipe.AddIngredient(null, "AtisBlood", 8);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}

	}
}
