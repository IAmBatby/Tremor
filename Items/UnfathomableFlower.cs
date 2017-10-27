using Terraria.ModLoader;

namespace Tremor.Items
{
	public class UnfathomableFlower : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 42;
			item.magic = true;
			item.width = 40;
			item.mana = 11;
			item.height = 20;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 60000;
			item.rare = 6;
			item.autoReuse = true;
			item.shoot = 248;
			item.shootSpeed = 12f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unfathomable Flower");
			Tooltip.SetDefault("");
		}

	}
}
