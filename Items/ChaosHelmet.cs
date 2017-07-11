using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Head)]
public class ChaosHelmet : ModItem
{



    public override void SetDefaults()
    {

        item.width = 32;
        item.height = 26;


        item.value = 6000;
        item.rare = 5;
        item.defense = 8;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Chaos Helmet");
      Tooltip.SetDefault("Increases maximum life by 25\nImmune to most debuffs!");
    }


    public override void UpdateEquip(Player p)
    {
                        p.statLifeMax2 += 25;
			p.buffImmune[44] = true;
			p.buffImmune[46] = true; 
			p.buffImmune[47] = true; 
			p.buffImmune[20] = true;
			p.buffImmune[22] = true; 
			p.buffImmune[24] = true; 
			p.buffImmune[23] = true; 
			p.buffImmune[30] = true; 
			p.buffImmune[31] = true; 
			p.buffImmune[32] = true; 
			p.buffImmune[33] = true; 
			p.buffImmune[35] = true; 
			p.buffImmune[36] = true; 
			p.buffImmune[69] = true; 
			p.buffImmune[70] = true;
			p.buffImmune[80] = true; 
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
return body.type == mod.ItemType("ChaosBreastplate") && legs.type == mod.ItemType("ChaosGreaves");
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Increases life regeneration";
	player.lifeRegen +=2;
    }

		public override void ArmorSetShadows(Player player)
		{
			        player.armorEffectDrawShadowLokis = true;
		}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "ChaosBar", 14);
        recipe.SetResult(this);
        recipe.AddTile(134);
        recipe.AddRecipe();
    }
}}
