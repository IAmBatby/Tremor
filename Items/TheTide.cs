using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TheTide : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 44;
			item.ranged = true;
			item.width = 52;
			item.height = 22;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 50000;

			item.rare = 5;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 27;
			item.shootSpeed = 26f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Tide");
			Tooltip.SetDefault("Shoots fast moving water bolts\n" +
"Uses bullets as ammo");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 27;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-16, 0);
		}
	}
}
