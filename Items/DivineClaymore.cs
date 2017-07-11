using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Tremor.Items {
public class DivineClaymore : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 232;
        item.melee = true;
        item.width = 46;
        item.height = 48;
        item.useTime = 30;
        item.useAnimation = 30;
        item.useStyle = 1;
        item.knockBack = 3;
			item.shoot = mod.ProjectileType("DivineClaymorePro");
			item.shootSpeed = 12f;
        item.value = 12400;
        item.rare = 0;
        item.UseSound = SoundID.Item15;
        item.autoReuse = true;
        item.useTurn = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Divine Claymore");
      Tooltip.SetDefault("");
    }


        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
        {
            tooltips[0].overrideColor = new Color(238, 194, 73);
        }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "VoidBlade", 1);
        recipe.AddIngredient(null, "AngeliteBar", 30);
        recipe.AddIngredient(null, "Aquamarine", 8);
        recipe.AddIngredient(null, "AngryShard", 3);
        recipe.AddIngredient(null, "Doomstone", 3);
        recipe.AddIngredient(ItemID.SoulofLight, 25);
        recipe.AddIngredient(null, "PurpleQuartz", 5);
        recipe.SetResult(this);
        recipe.AddTile(null, "DivineForgeTile");
        recipe.AddRecipe();
    }
}}
