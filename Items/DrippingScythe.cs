using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DrippingScythe : ModItem
	{
		public override void SetDefaults()
		{
			item.autoReuse = true;

			item.useStyle = 1;
			item.useAnimation = 20;
			item.useTime = 20;
			item.knockBack = 7f;
			item.width = 24;
			item.height = 28;
			item.damage = 297;
			item.UseSound = SoundID.Item71;
			item.rare = 11;
			item.shootSpeed = 15f;
			item.value = 450000;
			item.melee = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dripping Sickle");
			Tooltip.SetDefault("");
		}

	}
}
