using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RustyLantern : ModItem
	{

		const int XOffset = -400;
		const int YOffset = -400;

		public override void SetDefaults()
		{

			item.width = 14;
			item.height = 30;
			item.maxStack = 1;


			item.value = 3000;
			item.rare = 2;
			item.useTime = 40;
			item.useAnimation = 40;
			item.consumable = true;
			item.maxStack = 20;
			item.useStyle = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rusty Lantern");
			Tooltip.SetDefault("Summons Ancient Dragon\nCan be only used near Ruin Altar");
		}


		public override bool CanUseItem(Player player)
		{
			TremorPlayer modPlayer = player.GetModPlayer<TremorPlayer>(mod);
			return modPlayer.ruinAltar && !NPC.AnyNPCs(mod.NPCType("Dragon_HeadB"));
		}

		public override bool UseItem(Player player)
		{
			Main.NewText("Ancient Dragon has awoken!", 175, 75, 255);
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			//if(Main.netMode !=1)
			//{
			NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y + YOffset, mod.NPCType(""), 0, NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y + YOffset, mod.NPCType("Dragon_HeadB")));
			//}
			return true;
		}
	}
}
