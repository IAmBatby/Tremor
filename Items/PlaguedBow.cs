using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class PlaguedBow : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 56;
        item.width = 18;
        item.height = 56;
        item.ranged = true;
        item.useTime = 30;
        item.shoot = 1; 
        item.shootSpeed = 12f; 
        item.useAnimation = 30;
        item.useStyle = 5;
        item.knockBack = 5;
        item.value = 25000;
        item.useAmmo = AmmoID.Arrow;
        item.rare = 3;
        item.UseSound = SoundID.Item5;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Plagued Bow");
      Tooltip.SetDefault("");
    }


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("GhostlyArrow");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "ParaxydeShard", 14);
        recipe.AddTile(null, "AlchematorTile");
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}
