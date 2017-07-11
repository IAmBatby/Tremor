using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System.Linq;
using Terraria.ModLoader;

namespace Tremor.Items
{
    public class ToxicFlask : AlchemistItem
    {
        public override void SetDefaults()
        {
            item.damage = 46;
            item.width = 28;
            item.noUseGraphic = true;
            item.maxStack = 1;
            item.consumable = false;
            item.height = 28;
            item.useTime = 28;
            item.useAnimation = 28;
            item.shoot = mod.ProjectileType("ToxicFlaskPro");
            item.shootSpeed = 9f;
            item.useStyle = 1;
            item.knockBack = 4;
            item.noMelee = true;
            item.UseSound = SoundID.Item106;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 8;
            item.autoReuse = false;       
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toxic Flask");
            Tooltip.SetDefault("Throws a flask that explodes into toxic clouds");
        }

        public override void UpdateInventory(Player player)
        {
            if (player.FindBuffIndex(mod.BuffType("LongFuseBuff")) != -1)
            {
                item.shootSpeed = 11f;
            }
            if (player.FindBuffIndex(mod.BuffType("LongFuseBuff")) < 1)
            {
                item.shootSpeed = 9f;
            }
            if (player.FindBuffIndex(mod.BuffType("FlaskCoreBuff")) != -1)
            {
                item.autoReuse = true;
            }
            if (player.FindBuffIndex(mod.BuffType("FlaskCoreBuff")) < 1)
            {
                item.autoReuse = false;
            }
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.SetResult(3105);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(3105);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
