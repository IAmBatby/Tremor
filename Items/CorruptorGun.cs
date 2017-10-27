using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class CorruptorGun : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 26;
			item.ranged = true;
			item.width = 42;
			item.height = 30;

			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item40;
			item.autoReuse = false;
			item.shoot = 10;
			item.shootSpeed = 15f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corruptor Gun");
			Tooltip.SetDefault("Spends bullets and fires small corruptors");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 307;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override Vector2? HoldoutOffset()
		{
			return Vector2.Zero;
		}
	}
}
