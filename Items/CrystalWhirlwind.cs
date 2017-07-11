using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CrystalWhirlwind : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Starfury);

			item.damage = 85;
			item.melee = false;
			item.magic = true;
			item.width = 50;
			item.height = 55;
			item.useTime = 7;
			item.mana = 20;


			item.useAnimation = 30;
			item.useStyle = 5;
			item.shootSpeed = 30f;
			item.knockBack = 3;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item4;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Hail");
			Tooltip.SetDefault("Causes crystals to fall from the sky\n'Made of pure friendship''");
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 521;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalStorm, 1);
			recipe.AddIngredient(null, "NightmareBar", 10);
			recipe.AddIngredient(null, "Phantaplasm", 6);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
