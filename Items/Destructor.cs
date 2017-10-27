using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Destructor : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 40;
			item.ranged = true;
			item.width = 40;
			item.height = 40;

			item.useTime = 10;
			item.useAnimation = 10;
			item.shoot = 14;
			item.shootSpeed = 8f;
			item.useAmmo = AmmoID.Bullet;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 60000;
			item.rare = 5;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Destructor");
			Tooltip.SetDefault("'Exterminate!'");
		}

		public override bool ConsumeAmmo(Player p)
		{
			return Main.rand.NextBool(2);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
		}
	}
}
