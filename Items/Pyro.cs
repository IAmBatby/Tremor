using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Pyro : ModItem
	{

		public override bool CanEquipAccessory(Player player, int slot)
		{
			for (int i = 0; i < player.armor.Length; i++)
			{
				MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
				if (modPlayer.pyro == true)
				{
					return false;
				}
			}
			return true;
		}

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 300000;
			item.rare = 5;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Pyro");
			Tooltip.SetDefault("Alchemical flasks leaves an explosion");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
			player.AddBuff(mod.BuffType("PyroBuff"), 2);
			modPlayer.pyro = true;
		}
	}
}
