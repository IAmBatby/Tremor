using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CosmicAssaultRifle : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 190;
			item.width = 64;
			item.height = 28;
			item.ranged = true;
			item.useTime = 15;
			item.shoot = 207;

			item.shootSpeed = 20f;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 1000000;
			item.useAmmo = AmmoID.Bullet;
			item.rare = 11;
			item.crit = 7;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Assault Rifle");
			Tooltip.SetDefault("Uses bullets as ammo\n" +
"Shoots homing bullets");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 207;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-22, 0);
		}
	}
}
