using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class NightCombination : ModItem
{

    public override void SetDefaults()
    {

        item.width = 24;
        item.height = 28;
        item.value = 50000;
        item.rare = 1;
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Nightly Combination");
      Tooltip.SetDefault("Increases life regeneration, melee damage\nMakes you glow during night");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)

        {
           if (!Main.dayTime)
		   {
            player.AddBuff(11, 10);
            player.AddBuff(12, 10);
	    player.lifeRegen +=1;
	    player.meleeDamage +=0.1f;
            player.rangedDamage +=0.1f;
	    player.thrownDamage +=0.1f;
	    player.minionDamage +=0.1f;
	    player.magicDamage +=0.1f;
		   }  
        }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "Bloomstone");
        recipe.AddIngredient(null, "DragonGem");
        recipe.AddIngredient(null, "TwilightHorns");
        recipe.SetResult(this);
	recipe.AddTile(114);
        recipe.AddRecipe();
    }
}}
