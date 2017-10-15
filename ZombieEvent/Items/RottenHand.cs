using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class RottenHand : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 10;
			item.melee = true;
			item.width = 26;
			item.height = 26;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 3000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rotten Hand");
			Tooltip.SetDefault("");
		}
	}
}
