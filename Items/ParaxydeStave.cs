using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ParaxydeStave : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Starfury);

			item.damage = 68;
			item.melee = false;
			item.magic = true;
			item.width = 42;
			item.height = 46;
			item.useTime = 20;
			item.mana = 10;


			item.useAnimation = 20;
			item.useStyle = 1;
			item.shootSpeed = 10f;
			Item.staff[item.type] = true;
			item.knockBack = 3;
			item.value = 15000;
			item.rare = 5;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paraxyde Stave");
			Tooltip.SetDefault("Summons paraxyde crystals to fall from the sky\n");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ParaxydeShard", 11);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.SetResult(this);
			recipe.AddTile(null, "AlchematorTile");
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 521;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
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
