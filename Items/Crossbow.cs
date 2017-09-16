using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Crossbow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 11;
			item.noMelee = true;
			item.ranged = true;
			item.width = 16;
			item.height = 32;
			item.useTime = 30;
			item.shoot = 1;
			item.shootSpeed = 11f;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 10000;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 1;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crossbow");
			Tooltip.SetDefault("");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, -2);
		}
	}
}
