using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GoldenGlowingRing : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 10000;
			item.rare = 11;
			item.expert = true;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Glowing Ring");
			Tooltip.SetDefault("Summons two blades to protect you\nBlue has a chance to inflict confusion on enemy, yellow can inflict midas.");
		}

		public override void UpdateEquip(Player player)
		{
			player.AddBuff(mod.BuffType("GoldenGlowingRingBuff"), 2);
		}
	}
}
