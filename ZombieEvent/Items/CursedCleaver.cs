using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class CursedCleaver : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Arkhalis);

			item.damage = 36;

		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cursed Cleaver");
      Tooltip.SetDefault("Inflicts Cursed Flames on enemies");
    }


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("CursedCleaverPro");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(39, 120);
    }
	}
}
