using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FirebenderTome : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 36;
			item.useAnimation = 36;
			item.shoot = 706;
			item.shootSpeed = 7f;
			item.mana = 10;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Firebender Tome");
			Tooltip.SetDefault("");
		}

	}
}
