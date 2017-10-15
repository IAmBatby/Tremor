using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ChaosElement : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaos Element");
			Tooltip.SetDefault("Flasks spawn crystal splinters when destroyed\n" +
"Splinters heal you when hit enemy");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 100000;
			item.rare = 5;
			item.defense = 3;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("ChaosElementBuff"), 2);
			if (player.GetModPlayer<MPlayer>(mod).alchemicalCrit >= 30)
			{
				player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.1f;
			}
		}
	}
}