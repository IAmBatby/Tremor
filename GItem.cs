
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor
{
	public class TremorGlobalItem : GlobalItem
	{
		public override void ModifyHitNPC(Item item, Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			// If the item we're using to damage someone/something is an AlchemistItem.
			if (item.modItem is AlchemistItem)
			{
				MPlayer mp = player.GetModPlayer<MPlayer>(mod);
				// We want to multiply the damage we do by our alchemistDamage modifier.
				damage = (int)(damage * mp.alchemistDamage);
			}
		}
		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// Same for projectiles.
			if (item.modItem is AlchemistItem)
			{
				MPlayer mp = player.GetModPlayer<MPlayer>(mod);
				damage = (int)(damage * mp.alchemistDamage);
			}
			return true;
		}
	}
}
