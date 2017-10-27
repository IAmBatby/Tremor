using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Alchemist.Flasks
{
	public class FlaskCore : ModItem
	{
		public override bool CanEquipAccessory(Player player, int slot)
			=> !MPlayer.GetModPlayer(player).core;

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 24;

			item.value = 50000;
			item.rare = 6;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flask Core");
			Tooltip.SetDefault("Flasks now have autoreuse");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("FlaskCoreBuff"), 2);
		}
	}
}
