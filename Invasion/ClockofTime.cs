using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class ClockofTime : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 16;
			item.height = 16;

			item.value = 00001000;
			item.rare = 5;
			item.useTurn = true;
			item.autoReuse = false;
			item.useStyle = 4;
			item.useAnimation = 15;
			item.useTime = 15;
			item.maxStack = 1;
			item.mana = 100;
			item.UseSound = SoundID.Item8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradox Clock");
			Tooltip.SetDefault("Allows you to control the time");
		}

		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Main.bloodMoon = true;
				return true;
			}
			if (Main.netMode != 1)
			{
				Main.dayTime = !Main.dayTime;
				Main.time = (Main.dayTime ? 10000f : 0f);
				return true;
			}
			return true;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
	}
}
