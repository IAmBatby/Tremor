using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Legs)]
public class EnchantedGreaves : ModItem
{


    public override void SetDefaults()
    {

        item.width = 22;
        item.height = 18;


        item.value = 10000;
        item.rare = 2;
        item.defense = 5;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Enchanted Greaves");
      Tooltip.SetDefault("Increases maximum mana by 20\nIncreases maximum health by 15");
    }


    public override void UpdateEquip(Player player)
    {
        player.statManaMax2 += 20;
        player.statLifeMax2 += 15;
    }

}}
