using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tremor.Items
{
	public class ParaxydeAxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 66;
			item.melee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 16;
			item.useAnimation = 16;
			item.axe = 24;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 216000;
			item.rare = 5;
			item.tileBoost++;
			item.scale = 1.25f;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paraxyde Axe");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ParaxydeShard", 12);
			recipe.SetResult(this);
			recipe.AddTile(null, "AlchematorTile");
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 27);
			}
		}
	}
}
