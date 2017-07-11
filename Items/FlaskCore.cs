using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FlaskCore : ModItem
	{
		public override bool CanEquipAccessory(Player player, int slot)
		{
			for (int i = 0; i < player.armor.Length; i++)
			{
				MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
				if (modPlayer.core)
				{
					return false;
				}
			}
			return true;
		}

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
			MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
			player.AddBuff(mod.BuffType("FlaskCoreBuff"), 2);
			modPlayer.core = true;
		}
	}
}
