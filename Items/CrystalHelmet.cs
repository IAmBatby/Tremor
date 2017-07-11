using Terraria.ID;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Head)]
public class CrystalHelmet : ModItem
{

        public override void SetDefaults()
        {


            item.defense = 5;
            item.width = 26;
            item.height = 22;
            item.value = 2500;
            item.rare = 4;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Crystal Helmet");
      Tooltip.SetDefault("20% increased throwing damage");
    }


        public override void UpdateEquip(Player p)
        {
            p.thrownDamage += 0.2f;
        }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
            return body.type == mod.ItemType("CrystalChestplate") && legs.type == mod.ItemType("CrystalGreaves");
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Increases movement speed";
        player.moveSpeed += 0.25f;
    }

		public override void ArmorSetShadows(Player player)
		{
			        player.armorEffectDrawShadow=true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalShard, 30);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
