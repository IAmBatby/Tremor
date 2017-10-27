using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class LivingTombstonePro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(198);

			aiType = 198;
			Main.projFrames[projectile.type] = 4;
			projectile.width = 24;
			projectile.height = 36;
			Main.projPet[projectile.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Living Tombstone");

		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.bunny = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.dead)
			{
				modPlayer.LivingTombstone = false;
			}
			if (modPlayer.LivingTombstone)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}
