using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class WartimeRocketLauncher : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 220;
			item.ranged = true;
			item.width = 58;
			item.height = 34;
			item.useTime = 25;
			item.useAnimation = 25;
			item.shoot = 134;
			item.shootSpeed = 10f;
			item.useAmmo = AmmoID.Rocket;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 750000;
			item.rare = 11;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wartime Rocket Launcher");
			Tooltip.SetDefault("");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-14, -2);
		}
	}
}
