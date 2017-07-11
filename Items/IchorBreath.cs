using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class IchorBreath : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 55;
			item.thrown = true;
			item.width = 18;
			item.height = 18;
			item.useTime = 14;
			item.maxStack = 999;
			item.useAnimation = 14;
			item.shoot = mod.ProjectileType("IchorBreathPro");
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
			DisplayName.SetDefault("Ichor Breath");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DragonBreath", 25);
			recipe.AddIngredient(ItemID.Ichor, 3);
			recipe.SetResult(this, 25);
			recipe.AddTile(134);
			recipe.AddRecipe();

		}
	}
}
