using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion {

public class ParadoxPotion : ModItem
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
      DisplayName.SetDefault("Paradox Potion");
      Tooltip.SetDefault("Restores 300 health");
    }


		public override bool CanUseItem(Player player)
        {
			if (player.FindBuffIndex(BuffID.PotionSickness) == -1)    
            {
                player.AddBuff(BuffID.PotionSickness, 3600, true);
            }
            else
            {
                return false;  
            }
			return true;
        }

        public override bool UseItem(Player player)
        {
			Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 3);
			Main.player[Main.myPlayer].HealEffect(300);
			player.statLife += 300;
			return true;
        }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "ParadoxElement", 2);
        recipe.AddIngredient(ItemID.BottledWater);
        recipe.SetResult(this);
        recipe.AddTile(13);
        recipe.AddRecipe();
    }
}}
