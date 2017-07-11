using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Head)]
public class SniperHelmet : ModItem
{


    public override void SetDefaults()
    {

        item.width = 26;
        item.height = 26;


        item.value = 1000000;
        item.rare = 1;
        item.defense = 36;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sniper Helmet");
      Tooltip.SetDefault("15% increased ranged damage\n20% decreased movement speed");
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
return body.type == mod.ItemType("SniperBreastplate") && legs.type == mod.ItemType("SniperBoots");
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Increases projectile's speed twice";
        player.moveSpeed += 0.15f;
        player.AddBuff(mod.BuffType("ShootSpeedBuff"), 2);
        player.scope = true;
    }

		public override void ArmorSetShadows(Player player)
		{
			        player.armorEffectDrawShadow = true;
		}

    public override void UpdateEquip(Player player)
    {
          player.rangedDamage *= 1.15f;
          player.moveSpeed -= 0.20f;
    }


}}
