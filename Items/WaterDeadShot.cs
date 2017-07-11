using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tremor.Items {
public class WaterDeadShot : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 14;
        item.width = 18;
        item.height = 48;
        item.useTime = 30;
        item.ranged = true;
        item.shoot = 27; 


        item.shootSpeed = 23f; 
        item.useAnimation = 30;
        item.useStyle = 5;
        item.knockBack = 5;
        item.value = 250;
        item.useAmmo = AmmoID.Arrow;
        item.rare = 2;
        item.UseSound = SoundID.Item5;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Water Dead Shot");
      Tooltip.SetDefault("Shoots water streams\nUses arrows as ammo");
    }


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 27;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "SeaFragment", 8);
        recipe.AddIngredient(ItemID.Sapphire, 10);
        recipe.AddIngredient(ItemID.GoldBar, 6);
        recipe.AddTile(16);
        recipe.SetResult(this);
        recipe.AddRecipe();

        recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "SeaFragment", 8);
        recipe.AddIngredient(ItemID.Sapphire, 10);
        recipe.AddIngredient(ItemID.PlatinumBar, 6);
        recipe.AddTile(16);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}
