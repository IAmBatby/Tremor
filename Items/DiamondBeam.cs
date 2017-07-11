using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DiamondBeam : ModItem
	{
		public override void SetDefaults()
		{
			item.channel = true;
			item.damage = 288;
			item.magic = true;
			item.mana = 7;
			item.width = 40;
			item.height = 40;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 13800;
			item.rare = 4;
			item.UseSound = SoundID.Item43;
			item.autoReuse = false;
			Item.staff[item.type] = true;
			item.shoot = mod.ProjectileType("DiamondBeamPro");
			item.shootSpeed = 15f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Diamond Beam");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RuneBar", 12);
			recipe.AddIngredient(null, "Gloomstone", 15);
			recipe.AddIngredient(ItemID.Diamond, 10);
			recipe.AddIngredient(null, "LapisLazuli", 8);
			recipe.SetResult(this);
			recipe.AddTile(null, "DivineForgeTile");
			recipe.AddRecipe();
		}
	}
}
