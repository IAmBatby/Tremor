using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class HazardousChemicals : ModItem
{

    public override void SetDefaults()
    {

        item.width = 22;
        item.height = 44;

        item.value = 10000;
        item.rare = 3;
        item.maxStack = 1;
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Hazardous Chemicals");
      Tooltip.SetDefault("Increases alchemic damage by 5%");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.05f;
    }
}}
