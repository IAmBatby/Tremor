using Terraria.ID;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Items;

namespace Tremor.Items
{
	public class EaterofDreams : ModItem
	{

		public override void SetDefaults()
		{

			item.damage = 99;
			item.ranged = true;
			item.width = 76;
			item.height = 36;
			item.useTime = 10;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2f;
			item.UseSound = SoundID.Item34;
			item.value = 1253000;
			item.rare = 11;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("EaterofDreamsPro");
			item.shootSpeed = 7.5f;
			item.useAmmo = AmmoID.Gel;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eater of Dreams");
			Tooltip.SetDefault("Consumes gel as ammo");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NightmareBar", 16);
			recipe.AddIngredient(ItemID.Flamethrower, 1);
			recipe.AddIngredient(null, "PhantomSoul", 25);
			recipe.AddIngredient(null, "PurpleQuartz", 15);
			recipe.AddIngredient(null, "TearsofDeath", 8);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
