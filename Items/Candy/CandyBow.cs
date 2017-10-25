using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Candy
{
	public class CandyBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.ranged = true;
			item.width = 24;
			item.height = 46;
			item.useTime = 30;
			item.shoot = 1;
			item.shootSpeed = 8f;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 30000;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 1;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Candy Bow");
			Tooltip.SetDefault("");
		}

	}
}
