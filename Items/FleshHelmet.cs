using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Head)]
public class FleshHelmet : ModItem
{


    public override void SetDefaults()
    {

        item.width = 38;
        item.height = 22;


        item.value = 18000;
        item.rare = 1;
        item.defense = 7;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Flesh Helmet");
      Tooltip.SetDefault("5% increased minion damage\nIncreases your max number of minions");
    }


    public override void UpdateEquip(Player player)
    {
            player.maxMinions += 1;
            player.minionDamage += 0.05f;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
return body.type == mod.ItemType("FleshBreastplate") && legs.type == mod.ItemType("FleshGreaves");
    }

    public override void UpdateArmorSet(Player p)
    {
        p.setBonus = "Increases regeneration!";
	p.crimsonRegen = true;
    }

		public override void ArmorSetShadows(Player player)
		{
			        player.armorEffectDrawShadow=true;
		}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "PieceofFlesh", 4);
        recipe.SetResult(this);
        recipe.AddTile(16);
        recipe.AddRecipe();
    }

}}
