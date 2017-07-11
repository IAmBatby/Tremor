using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class StrangeEgg : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);

			item.useTime = 25;
			item.useAnimation = 25;
			item.rare = 11;

			item.shoot = mod.ProjectileType("Brutty");
			item.buffType = mod.BuffType("BruttyBuff");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Strange Egg");
			Tooltip.SetDefault("Summons an brutty");
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
