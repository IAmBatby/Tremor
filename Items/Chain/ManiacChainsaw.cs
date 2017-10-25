using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Chain
{

	public class ManiacChainsaw : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 202;
			item.melee = true;
			item.width = 140;
			item.height = 34;
			item.useTime = 8;
			item.useAnimation = 25;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.axe = 35;
			item.tileBoost += 5;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = Item.buyPrice(0, 1, 50, 0);
			item.rare = 10;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;

			item.shoot = mod.ProjectileType("ManiacChainsawPro");
			item.shootSpeed = 0.4f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Maniacal Chainsaw");
			Tooltip.SetDefault("'A weapon of a true man killer'");
		}

	}
}
