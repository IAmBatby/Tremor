using Terraria;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class SunBoots : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 28;
			item.value = 00150000;
			item.rare = 11;

			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradox Boots");
			Tooltip.SetDefault("Allows you to control gravity\n" +
"Increases speed and regeneration, increases maximum health by 50");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.5f;
			player.lifeRegen += 2;
			player.statLifeMax2 += 50;
			player.accRunSpeed = 10f;
			player.gravControl = true;
		}
	}
}
