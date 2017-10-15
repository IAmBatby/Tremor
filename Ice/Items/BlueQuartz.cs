using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tremor.Ice.Items
{
	public class BlueQuartz : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;
			item.value = 17500;
			item.rare = 1;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue Quartz");
			Tooltip.SetDefault("Increases maximum health by 50 \n6% increased damage if in Glacier or Snow biome");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
		}

		public override void UpdateEquip(Player player)
		{
			if (player.ZoneSnow)
			{
				player.statLifeMax2 += 50;
				player.meleeDamage += 0.06f;
				player.rangedDamage += 0.06f;
				player.magicDamage += 0.06f;
				player.thrownDamage += 0.06f;
				player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.06f;
			}
		}
	}
}
