using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class HornedWarHammer : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Arkhalis);

			item.damage = 350;
			item.knockBack = 4;
			item.rare = 11;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Horned War Hammer");
			Tooltip.SetDefault("Forged from lightning");
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("HornedWarhammerPro");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

	}
}
