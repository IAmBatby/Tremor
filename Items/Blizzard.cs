using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Blizzard : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 35;
			item.melee = false;
			item.magic = true;
			item.width = 50;
			item.height = 55;
			item.useTime = 12;
			item.useAnimation = 12;
			item.mana = 8;
			item.useStyle = 5;
			item.shoot = 337;
			item.shootSpeed = 26f;
			item.knockBack = 4;
			item.value = 100000;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blizzard");
			Tooltip.SetDefault("");
		}

	}
}
