using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Decayed : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.ranged = true;
			item.width = 60;
			item.height = 22;
			item.useTime = 15;
			item.useAnimation = 15;
			item.shoot = 10;
			item.shootSpeed = 12f;
			item.useAmmo = AmmoID.Bullet;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Decayed");
			Tooltip.SetDefault("");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-16, 0);
		}
	}
}
