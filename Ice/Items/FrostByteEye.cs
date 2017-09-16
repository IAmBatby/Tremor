using Terraria;
using Terraria.ModLoader;

namespace Tremor.Ice.Items
{
	public class FrostByteEye : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 22;
			item.value = 6000;

			item.rare = 1;
			item.accessory = true;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostbyte Eye");
			Tooltip.SetDefault("10% increased move speed and increased jump height");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.moveSpeed += 0.1f;
			player.jumpBoost = true;
		}
	}
}
