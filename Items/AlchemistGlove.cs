using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AlchemistGlove : ModItem
	{
		public override bool CanEquipAccessory(Player player, int slot)
		{
			for (int i = 0; i < player.armor.Length; i++)
			{
				MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
				if (modPlayer.glove == true)
				{
					return false;
				}
			}
			return true;
		}

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 38;

			item.value = 1500000;
			item.rare = 7;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Master Alchemist Glove");
			Tooltip.SetDefault("Alchemic weapons throw two flasks instead of one");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
			player.AddBuff(mod.BuffType("AlchemistGloveBuff"), 2);
			modPlayer.glove = true;
		}
	}
}
