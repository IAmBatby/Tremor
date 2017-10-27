using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Crystal
{
	class UnstableCrystal : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 44;
			item.height = 48;

			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 4;
			item.knockBack = 0;
			item.shoot = 1;
			item.value = 10000;
			item.rare = 1;
			item.consumable = true;
			item.maxStack = 999;
			item.UseSound = SoundID.Item6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unstable Crystal");
			Tooltip.SetDefault("Teleports you to a random location\n" +
"'Be careful! It can take you to a very dangerous place!'");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.TeleportationPotion();
			return false;
		}
	}
}
