using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CursedBreath : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 56;
			item.thrown = true;
			item.width = 18;
			item.height = 18;
			item.useTime = 14;
			item.useAnimation = 14;
			item.maxStack = 999;
			item.shoot = mod.ProjectileType("CursedBreathPro");
			item.shootSpeed = 8f;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 155;
			item.rare = 5;
			item.consumable = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Breath");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DragonBreath", 25);
			recipe.AddIngredient(ItemID.CursedFlame, 3);
			recipe.SetResult(this, 25);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
