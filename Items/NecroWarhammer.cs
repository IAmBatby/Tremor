using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NecroWarhammer : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 73;
			item.melee = true;
			item.width = 38;
			item.height = 20;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 150000;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = 270;
			item.shootSpeed = 12f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Necro War Hammer");
			Tooltip.SetDefault("");
		}

	}
}
