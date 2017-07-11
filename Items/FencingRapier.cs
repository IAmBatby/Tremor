using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FencingRapier : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 19;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 3;
			item.knockBack = 6;
			item.value = 660;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fencing Rapier");
			Tooltip.SetDefault("");
		}

	}
}
