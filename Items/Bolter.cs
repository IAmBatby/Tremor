using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Bolter : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 43;
			item.ranged = true;
			item.width = 46;
			item.height = 32;

			item.useTime = 9;
			item.useAnimation = 9;
			item.shoot = 1;
			item.useAmmo = AmmoID.Arrow;
			item.shootSpeed = 30f;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 90000;
			item.rare = 7;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bolter");
			Tooltip.SetDefault("Quickly launches arrows\n" +
"Has 50% chance to shoot a Hellfire arrow");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.NextBool(2))
			{
				type = 41;
			}

			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}
