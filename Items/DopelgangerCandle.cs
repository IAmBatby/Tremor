using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DopelgangerCandle : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 36;
			item.value = 1250;
			item.rare = 5;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dopelganger Candle");
			Tooltip.SetDefault("'Takes a piece of your soul in return for additional minion'\n" +
"6% increased minion damage");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 -= 25;
			player.maxMinions += 1;
			player.minionDamage += 0.06f;
		}
	}
}
