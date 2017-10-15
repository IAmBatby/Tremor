using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AncientSoul : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 36;

			item.rare = 9;
			item.accessory = true;
			item.value = 30000;
			item.expert = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Soul");
			Tooltip.SetDefault("Creates a shield of souls to protect you\n" +
"More souls appear after some time and each soul disappear after second hit of enemy");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 3));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (Main.rand.Next(250) == 0)
			{
				if (player.ownedProjectileCounts[mod.ProjectileType("AncientShield")] <= 4)
				{
					Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("AncientShield"), 20, 0, player.whoAmI);
				}
			}
		}
	}
}
