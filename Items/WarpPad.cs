using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class WarpPad : ModItem
	{

		public override void SetDefaults()
		{

			item.UseSound = SoundID.Item6;
			item.useStyle = 4;
			item.useAnimation = 30;
			item.useTime = 30;
			item.width = 32;
			item.height = 32;

			item.value = 60000;
			item.rare = 8;
			item.mana = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Warp Pad");
			Tooltip.SetDefault("Teleports you to your last death point upon use");
		}

		public override bool UseItem(Player player)
		{
			if (player.lastDeathPostion != player.position && player.showLastDeath)
			{
				player.Teleport(player.lastDeathPostion, 1, 0);
				//NetMessage.SendData(65, -1, -1, "", 0, player.whoAmI, player.lastDeathPostion.X, player.lastDeathPostion.Y, 1, 0, 0);
				player.showLastDeath = false;
				return true;
			}
			return false;
		}

		public override bool CanUseItem(Player player)
		{
			if (!player.showLastDeath)
			{
				return false;
			}
			return true;
		}
	}
}
