using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class FrostKingBag : ModItem
{
    public override void SetDefaults()
    {

        item.maxStack = 999;
        item.consumable = true;
        item.width = 24;
        item.height = 24;

        item.rare = 9;
        item.expert = true;
        bossBagNPC = mod.NPCType("FrostKing");
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
            player.QuickSpawnItem(mod.ItemType("FrostKingMask"));
        }
        player.QuickSpawnItem(mod.ItemType("EdgeofFrostKing"));
        player.QuickSpawnItem(mod.ItemType("FrostoneOre"), Main.rand.Next(24,42));
        player.TryGettingDevArmor();
    }

}}
