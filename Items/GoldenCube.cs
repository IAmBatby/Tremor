using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GoldenCube : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);

			item.useTime = 25;
			item.useAnimation = 25;

			item.shoot = mod.ProjectileType("GoldenWhalePro");
			item.buffType = mod.BuffType("GoldenWhale");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Cube");
			Tooltip.SetDefault("Summons an golden whale");
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
