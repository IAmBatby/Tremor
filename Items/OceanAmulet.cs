using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class OceanAmulet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 34;

			item.rare = 5;
			item.accessory = true;
			item.value = 50000;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ocean Amulet");
			Tooltip.SetDefault("Extends underwater breathing\n" +
"Increases fishing skill by 12 and allows to detect catched fish");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.fishingSkill += 12;
			player.accDivingHelm = true;
			player.AddBuff(122, 60, true);
		}
	}
}
