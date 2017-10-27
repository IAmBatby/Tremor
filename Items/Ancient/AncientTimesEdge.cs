using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Ancient
{
	public class AncientTimesEdge : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.melee = true;
			item.width = 36;
			item.height = 44;
			item.useTime = 35;

			item.useAnimation = 35;
			item.useStyle = 1;
			item.useTurn = true;
			item.knockBack = 6f;
			item.value = 30000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 15f;
			item.shoot = 270;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Times Edge");
			Tooltip.SetDefault("Summons ancient skulls on swing");
		}

	}
}
