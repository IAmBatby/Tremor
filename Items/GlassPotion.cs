using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {

public class GlassPotion : ModItem
{
    public override void SetDefaults()
    {

        item.width = 38;
        item.height = 32;
        item.maxStack = 20;

        item.rare = 11;
        item.useAnimation = 15;
        item.useTime = 15;
        item.useStyle = 2;
        item.UseSound = SoundID.Item3;
        item.consumable = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Glass Potion");
      Tooltip.SetDefault("Increases all damage by three times but reduces defense to zero");
    }


        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("FragileCondition"), 14400);
            return true;
        }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.BottledWater, 1);
        recipe.AddIngredient(null, "AtisBlood", 1);
        recipe.AddIngredient(null, "AlienTongue", 1);
        recipe.AddIngredient(null, "SpiderMeat", 1);
        recipe.AddTile(null, "AlchemyStationTile");
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}
