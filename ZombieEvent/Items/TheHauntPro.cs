using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class TheHauntPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
			Main.projFrames[projectile.type] = 4;
			projectile.width = 72;
			//projectile.noGravity = true;
			projectile.height = 38;
			Main.projPet[projectile.type] = true;
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
				modPlayer.hauntpet = false;
			}
			if (modPlayer.hauntpet)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}
