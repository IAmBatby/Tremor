using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ThrowingAxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 15;
			item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("ThrowingAxe");
			item.shootSpeed = 10f;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 14;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Throwing Axe");
			Tooltip.SetDefault("");
		}

	}
}
