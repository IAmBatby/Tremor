using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Invasion
{
	public class ParadoxTitanBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("Titan");
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
			player.TryGettingDevArmor();
			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("ParadoxTitanMask"));
			}
			if (Main.rand.Next(20) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("VioleumWings"));
			}			
        switch (Main.rand.Next(4)) 
        { 
             case 0: 
             player.QuickSpawnItem(mod.ItemType("TheEtherealm")); 
             break; 
             case 1: 
             player.QuickSpawnItem(mod.ItemType("RocketWand")); 
             break; 
             case 2: 
             player.QuickSpawnItem(mod.ItemType("SoulFlames")); 
             break; 			 
        }
			player.QuickSpawnItem(mod.ItemType("HealingPotion"), Main.rand.Next(7, 20));
            player.QuickSpawnItem(mod.ItemType("TimeTissue"), Main.rand.Next(5, 15));
			player.QuickSpawnItem(mod.ItemType("Relayx"));
			player.QuickSpawnItem(mod.ItemType("ClockofTime"));
		}
	}
}
