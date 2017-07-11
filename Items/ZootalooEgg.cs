using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ZootalooEgg : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);

			item.useTime = 25;
			item.useAnimation = 25;

			item.shoot = mod.ProjectileType("ZootalooPet");
			item.buffType = mod.BuffType("ZootalooBuff");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zootaloo Egg");
			Tooltip.SetDefault("Summons an zootaloo junior");
		}


		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}
