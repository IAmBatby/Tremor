using Terraria.ID;

namespace Tremor.Ice.Items
{
	public class FrostLiquidFlask : AlchemistItem
	{
		public override void SetDefaults()
		{
			item.damage = 10;
			//item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("FrostLiquidFlaskPro");
			item.shootSpeed = 8f;
			item.useStyle = 1;
			item.knockBack = 1;
			item.UseSound = SoundID.Item106;
			item.value = 30;
			item.rare = 1;
			item.autoReuse = false;
			item.crit = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Liquid Flask");
			Tooltip.SetDefault("Throws a flask that explodes into frost bolts");
		}
	}
}
