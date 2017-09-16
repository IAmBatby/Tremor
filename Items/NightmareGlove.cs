using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NightmareGlove : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 125;
			item.melee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 100000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightmare Glove");
			Tooltip.SetDefault("");
		}

	}
}
