using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class AncientPredatorBuff : ModBuff
	{
		int MinionType = -1;
		int MinionID = -1;

		public override void SetDefaults()
		{
			DisplayName.SetDefault("The Ancient Predator");
			Description.SetDefault("The ancient predator defends you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}


		public override void Update(Player player, ref int buffIndex)
		{
			if (MinionType == -1)
				MinionType = mod.ProjectileType("AncientPredator");
			if (MinionID == -1 || Main.projectile[MinionID].type != MinionType || !Main.projectile[MinionID].active || Main.projectile[MinionID].owner != player.whoAmI)
			{
				Projectile proj = new Projectile();
				proj.SetDefaults(MinionType);
				MinionID = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, MinionType, 300, 3, player.whoAmI);
			}
			else
			{
				Main.projectile[MinionID].timeLeft = 5;
			}
		}
	}
}