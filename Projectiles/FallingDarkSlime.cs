using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class FallingDarkSlime : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 36;
			projectile.height = 32;
			projectile.light = 0.8f;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.penetrate = 6;
			Main.projFrames[projectile.type] = 4;
			projectile.aiStyle = 1;
			projectile.timeLeft = 600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("FallingDarkSlime");

		}

		public override void AI()
		{
			if (projectile.frameCounter < 5)
				projectile.frame = 0;
			else if (projectile.frameCounter >= 5 && projectile.frameCounter < 10)
				projectile.frame = 1;
			else if (projectile.frameCounter >= 10 && projectile.frameCounter < 15)
				projectile.frame = 2;
			else if (projectile.frameCounter >= 15 && projectile.frameCounter < 20)
				projectile.frame = 3;
			else
				projectile.frameCounter = 0;
			projectile.frameCounter++;
		}

		public override void Kill(int timeLeft)
		{
			NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, mod.NPCType("DarkSlime"));
		}
	}
}
