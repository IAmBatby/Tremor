using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PoisonRod : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 21;
			item.melee = true;
			item.width = 50;
			item.height = 52;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.shoot = 265;
			item.shootSpeed = 10f;
			item.knockBack = 4;
			item.value = 40000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Poison Rod");
			Tooltip.SetDefault("");
		}

	}
}
