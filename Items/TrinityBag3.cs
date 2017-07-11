using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class TrinityBag3 : ModItem
{
    public override void SetDefaults()
    {

        item.maxStack = 999;
        item.consumable = true;
        item.width = 24;
        item.height = 24;

        item.rare = 9;
        item.expert = true;
        bossBagNPC = mod.NPCType("SoulofHope");
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Treasure Bag");
      Tooltip.SetDefault("Right click to open");
    }


    public override bool CanRightClick()
    {
        return true;
    }

    public override void OpenBossBag(Player player)
    {
        if(Main.rand.Next(7) == 0)
        {
            player.QuickSpawnItem(mod.ItemType("HopeMask"));
        }
        if(Main.rand.Next(7) == 0)
        {
            player.QuickSpawnItem(mod.ItemType("TrustMask"));
        }
        if(Main.rand.Next(7) == 0)
        {
            player.QuickSpawnItem(mod.ItemType("TruthMask"));
        }
        if(Main.rand.Next(3) == 0)
        {
            player.QuickSpawnItem(mod.ItemType("Banhammer"));
        }
        if(Main.rand.Next(3) == 0)
        {
            player.QuickSpawnItem(mod.ItemType("BestNightmare"));
        }
        if(Main.rand.Next(3) == 0)
        {
            player.QuickSpawnItem(mod.ItemType("HonestBlade"));
        }
        if(Main.rand.Next(3) == 0)
        {
            player.QuickSpawnItem(mod.ItemType("Volcannon"));
        }
        if(Main.rand.Next(3) == 0)
        {
            player.QuickSpawnItem(mod.ItemType("TrebleClef"));
        }
        if(Main.rand.Next(3) == 0)
        {
            player.QuickSpawnItem(mod.ItemType("Revolwar"));
        }
            player.QuickSpawnItem(mod.ItemType("Unpredictable�ompass"));
            player.QuickSpawnItem(mod.ItemType("OmnikronBar"), Main.rand.Next(20, 36));
            player.QuickSpawnItem(mod.ItemType("TrueEssense"), Main.rand.Next(10, 25));
    }
}}
