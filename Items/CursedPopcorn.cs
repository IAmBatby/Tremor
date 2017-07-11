using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {

public class CursedPopcorn : ModItem
{

    public override void SetDefaults()
    {

        item.width = 26;
        item.height = 34;
        item.maxStack = 20;

        item.rare = 2;
        item.value = 50000;
        item.useAnimation = 45;
        item.useTime = 45;
        item.useStyle = 4;
        item.consumable = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cursed Popcorn");
      Tooltip.SetDefault("Summons the Evil Corn");
    }


    public override bool CanUseItem(Player player)
    {
        return !Main.dayTime && !NPC.AnyNPCs(mod.NPCType("EvilCorn"));
    }

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("EvilCorn"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
}}
