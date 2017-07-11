using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Cyclone : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 84;
			item.width = 14;
			item.height = 84;
			item.magic = true;
			item.mana = 16;
			item.useTime = 12;
			item.useAnimation = 12;
			item.shoot = mod.ProjectileType("CyclonePro");
			item.shootSpeed = 4f;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 230000;
			item.rare = 10;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cyclone");
			Tooltip.SetDefault("");
		}



		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AncientTechnology", 1);
			recipe.AddIngredient(3457, 30);
			recipe.AddIngredient(null, "SeaFragment", 25);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
