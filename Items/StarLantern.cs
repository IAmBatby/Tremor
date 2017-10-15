using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class StarLantern : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;
			item.value = 50000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star Lantern");
			Tooltip.SetDefault("25% increased magic damage\n" +
"Emits aura of light");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(11, 10);
			player.magicDamage += 0.25f;
		}
	}
}
