using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class DesertClaymorePro : ModProjectile
	{
		const int MaxYOffset = 5;
		const int SpeedMulti = 2;
		const int XOffset = 24; // На сколько блоков от игрока будет появлятся меч. (16ед. == 1 блок.)

		int YOffset;
		int YOffsetStep = -1;
		bool UP = true;
		float YPos;

		public override void SetDefaults()
		{

			projectile.width = 30;
			projectile.tileCollide = false;
			projectile.height = 60;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 1080; // Время которое он будет стоять на месте (60ед. == 1сек.)
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Claymore");

		}

		bool FirstAI = true;
		public override void AI()
		{
			if (FirstAI)
			{
				YPos = projectile.position.Y;
				if (projectile.ai[0] == -1)
					projectile.position.X -= XOffset;
				else
					projectile.position.X += XOffset;
				FirstAI = false;
			}
			if (projectile.aiStyle == 0)
			{
				if (UP)
				{
					YOffset += YOffsetStep;
					if (YOffset <= -MaxYOffset)
						UP = false;
				}
				else
				{
					YOffset -= YOffsetStep;
					if (YOffset >= MaxYOffset)
						UP = true;
				}
				projectile.position = new Vector2(projectile.position.X, YPos + YOffset);
			}
			if (projectile.timeLeft == 2)
			{
				++projectile.timeLeft;
				projectile.aiStyle = 3;
			}
			if (projectile.aiStyle == 3)
				projectile.position += projectile.velocity * (SpeedMulti - 1);
		}
	}
}
