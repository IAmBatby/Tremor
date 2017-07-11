using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Infernality : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 20;
			item.melee = true;
			item.width = 40;
			item.height = 40;

			item.useTime = 25;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 25025;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infernality");
			Tooltip.SetDefault("'For the glory of Satan of course!'");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddIngredient(null, "PhantomSoul", 5);
			recipe.AddIngredient(null, "DemonBlood", 12);
			recipe.AddTile(null, "DevilForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6);
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 1000);
		}
	}
}
