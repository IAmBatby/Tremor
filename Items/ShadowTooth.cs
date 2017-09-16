using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ShadowTooth : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 50;
			item.melee = true;
			item.width = 42;
			item.height = 46;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = 121;
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
			DisplayName.SetDefault("Shadow Tooth");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddIngredient(ItemID.SoulofSight, 8);
			recipe.AddIngredient(null, "ColdTooth", 1);
			recipe.AddTile(null, "GreatAnvilTile");
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddIngredient(ItemID.SoulofSight, 8);
			recipe.AddIngredient(null, "FlamingTooth", 1);
			recipe.AddTile(null, "GreatAnvilTile");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(153, 120);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool())
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 65);
			}
		}
	}
}
