using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class TrueTerraBlade : ModItem
{
    public override void SetDefaults()
    {
				item.rare = 10;
				item.UseSound = SoundID.Item1;

				item.useStyle = 1;
				item.damage = 196;
				item.useAnimation = 16;
				item.useTime = 14;
				item.width = 84;
				item.height = 84;
				item.shoot = 132;
				item.scale = 1.1f;
				item.shootSpeed = 15f;
				item.knockBack = 6.5f;
				item.melee = true;
				item.value = Item.sellPrice(0, 20, 0, 0);
				item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("True Terra Blade");
      Tooltip.SetDefault("'Shining, shimmering, splendid!'");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TerraBlade, 1);
			recipe.AddIngredient(null, "NightmareBar", 25);
			recipe.AddIngredient(null, "SeaFragment", 30);
			recipe.AddIngredient(null, "EarthFragment", 30);
			recipe.AddIngredient(null, "FireFragment", 30);
			recipe.AddIngredient(null, "AirFragment", 30);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}}
