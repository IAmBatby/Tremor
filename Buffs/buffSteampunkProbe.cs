using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class buffSteampunkProbe : ModBuff
	{
		int Probe = -1;

		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("SteampunkProbe");
			Description.SetDefault("This probe protects you.");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.buffTime[buffIndex] >= 2)
			{
				if (Probe == -1)
					Probe = Projectile.NewProjectile(player.position.X, player.position.Y, 0, 0, mod.ProjectileType("projSteampunkProbe"), 0, 0, player.whoAmI);
				if (!Main.projectile[Probe].active || Main.projectile[Probe].type != mod.ProjectileType("projSteampunkProbe"))
				{
					Probe = Projectile.NewProjectile(player.position.X, player.position.Y, 0, 0, mod.ProjectileType("projSteampunkProbe"), 0, 0, player.whoAmI);
				}
				Main.projectile[Probe].timeLeft = 6;
			}
			else
			{
				if (Probe != -1)
				{
					Main.projectile[Probe].active = false;
				}
			}
		}
	}
}