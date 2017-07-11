using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RazorleavesTome : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 5;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 12;
			item.useAnimation = 12;
			item.shoot = 206;
			item.shootSpeed = 11f;
			item.mana = 6;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Razorleaves Tome");
			Tooltip.SetDefault("");
		}

	}
}
