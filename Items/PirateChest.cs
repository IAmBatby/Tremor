using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class PirateChest : ModItem
{
    public override void SetDefaults()
    {

        item.maxStack = 999;
        item.consumable = true;
        item.width = 34;
        item.height = 34;
        item.value = 20000;


        item.rare = 5;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Pirate Chest");
      Tooltip.SetDefault("Right click to open\n'Contains precious things'");
    }


    public override bool CanRightClick()
    {
        return true;
    }

    public override void RightClick(Player player)
    {
        if(Main.rand.Next(10) == 0)
        {
            player.QuickSpawnItem(2854);
        }
        if(Main.rand.Next(5) == 0)
        {
            player.QuickSpawnItem(672);
        }
        if(Main.rand.Next(25) == 0)
        {
            player.QuickSpawnItem(905);
        }
        if(Main.rand.Next(15) == 0)
        {
            player.QuickSpawnItem(855);;
        }
        if(Main.rand.Next(10) == 0)
        {
            player.QuickSpawnItem(854);
        }
        if(Main.rand.Next(15) == 0)
        {
            player.QuickSpawnItem(3033);
        }
        if(Main.rand.Next(6) == 0)
        {
            player.QuickSpawnItem(mod.ItemType("HandCannon"));
        }
        if(Main.rand.Next(6) == 0)
        {
            player.QuickSpawnItem(mod.ItemType("PirateFlag"));
        }
        if(Main.rand.Next(1) == 0)
        {
            player.QuickSpawnItem(73, Main.rand.Next(9, 18));
        }
        if(Main.rand.Next(2) == 0)
        {
            player.QuickSpawnItem(19, Main.rand.Next(14, 19));;
        }
        if(Main.rand.Next(2) == 0)
        {
            player.QuickSpawnItem(706, Main.rand.Next(14, 19));;
        }
    }

}}
