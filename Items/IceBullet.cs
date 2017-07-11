using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class IceBullet : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 11;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;

			item.consumable = true;
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = 2;
			item.shoot = mod.ProjectileType("IceBullet");
			item.shootSpeed = 8f;
			item.ammo = AmmoID.Bullet;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ice Bullet");
      Tooltip.SetDefault("25% chance to inflict frostburn");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 100);
			recipe.AddIngredient(ItemID.IceBlock, 30);
			recipe.AddTile(16);
			recipe.SetResult(this, 100);
			recipe.AddRecipe();
		}
	}
}
