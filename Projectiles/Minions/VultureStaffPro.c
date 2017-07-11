using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Minions
{
	  
	public class VultureStaffPro : HoverShooter
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			item.name = "Vulture";
			projectile.width = 46;
			projectile.height = 36;
			Main.projFrames[projectile.type] = 4;
			projectile.friendly = true;
			Main.projPet[projectile.type] = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			inertia = 20f;
			shoot = mod.ProjectileType("VultureFeather");
			shootSpeed = 12f;
		}

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			TremorPlayer modPlayer = (ExamplePlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.dead)
			{
				modPlayer.vultureMinion = false;
			}
			if (modPlayer.vultureMinion)
			{
				projectile.timeLeft = 2;
			}
		}

		public override void SelectFrame()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			}
		}
	}
}