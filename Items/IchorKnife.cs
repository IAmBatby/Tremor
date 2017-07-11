using Terraria.ID;
using System;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class IchorKnife : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 23;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 11;
			item.useAnimation = 9;
			item.useStyle = 3;
			item.knockBack = 2;
			item.value = 2800;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ichor Knife");
			Tooltip.SetDefault("");
		}


		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(69, 60);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RipperKnife");
			recipe.AddIngredient(ItemID.Ichor, 20);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 57);
			}
		}
	}
}
