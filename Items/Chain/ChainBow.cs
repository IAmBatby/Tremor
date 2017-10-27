using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Chain
{
	public class ChainBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 300;
			item.width = 16;
			item.height = 32;
			item.ranged = true;
			item.useTime = 20;
			item.shoot = 1;

			item.shootSpeed = 60f;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 1250000;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 11;
			item.crit = 7;
			item.UseSound = SoundID.Item114;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chain Bow");
			Tooltip.SetDefault("Shoots cosmic rays!");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 255;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}
