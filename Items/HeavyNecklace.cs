using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class HeavyNecklace : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 34;
			item.value = 100000;
			item.rare = 2;

			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heavy Necklace");
			Tooltip.SetDefault("5% increased damage");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.meleeDamage += 0.05f;
			player.rangedDamage += 0.05f;
			player.magicDamage += 0.05f;
			player.minionDamage += 0.05f;
			player.thrownDamage += 0.05f;
		}
	}
}
