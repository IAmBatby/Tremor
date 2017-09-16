using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PixiePulse : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 46;
			item.magic = true;
			item.width = 46;
			item.height = 26;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item12;
			item.autoReuse = true;
			item.shoot = 88;
			item.shootSpeed = 5f;
			item.mana = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pixie Pulse");
			Tooltip.SetDefault("");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}
	}
}
