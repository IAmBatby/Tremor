using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class LinearBurst : ModItem
{
    public override bool CanEquipAccessory(Player player, int slot)
     {
       for(int i=0; i < player.armor.Length; i++)
         {
	     MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
             if(modPlayer.nitro == true)
             {
                return false;
             }
         }
       return true;
     }

    public override void SetDefaults()
    {

        item.width = 22;
        item.height = 44;

        item.value = 300000;
        item.rare = 6;
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Linear Burst");
      Tooltip.SetDefault("Achemical flasks leave five death flames");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.ExplosivePowder, 15);
        recipe.AddIngredient(null, "ReinforcedBurst", 1);
        recipe.AddIngredient(ItemID.SoulofLight, 10);
        recipe.AddIngredient(ItemID.SoulofNight, 10);
        recipe.AddIngredient(ItemID.HallowedBar, 15);
        recipe.SetResult(this);
	recipe.AddTile(114);
        recipe.AddRecipe();
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
		MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
		player.AddBuff(mod.BuffType("LinearBurstBuff"), 2);
		modPlayer.nitro = true;
    }
}}
