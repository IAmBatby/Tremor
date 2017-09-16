using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MassiveHammer : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 28;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 25;
			item.useAnimation = 45;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 12000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Massive Hammer");
			Tooltip.SetDefault("");
		}

	}
}
