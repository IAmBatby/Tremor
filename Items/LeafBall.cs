using Terraria.ID;
using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
    public class LeafBall : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 30;
            item.height = 10;

            item.value = Item.sellPrice(0, 0, 25, 0);
            item.rare = 2;
            item.noMelee = true;
            item.useStyle = 5;
            item.useAnimation = 40; 
            item.useTime = 40; 
            item.knockBack = 7.5F;
            item.damage = 16;
            item.scale = 1.1F;
            item.noUseGraphic = true;
            item.shoot = mod.ProjectileType("LeafBallPro");
            item.shootSpeed = 15.9F;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.channel = true; 
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Leaf Ball");
      Tooltip.SetDefault("'Flail from grass and leaves'");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RichMahogany, 15);
            recipe.AddIngredient(ItemID.Vine, 1);
            recipe.AddIngredient(ItemID.Stinger, 3);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
