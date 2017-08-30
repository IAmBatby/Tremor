using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tremor.CogLord.NPCs
{
	/*
	 * npc.ai[0] = Index of the Cog Lord boss in the Main.npc array.
	 * npc.ai[1] = State manager.
	 * npc.ai[2] = (Shoot) timer.
	 */

	public class CogLordGun : ModNPC
	{
		NPC cogLord => Main.npc[(int)npc.ai[0]];

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord Gun");
		}

		const int shootRate = 120;
		const int ShootDamage = 20;
		const float ShootKN = 1.0f;
		const int ShootType = 88;
		const float ShootSpeed = 5;
		const int ShootCount = 10;
		const int spread = 45;
		const float spreadMult = 0.045f;
		const float MaxDist = 250f;

		public override void SetDefaults()
		{
			npc.width = 88;
			npc.height = 46;

			npc.damage = 80;
			npc.defense = 20;
			npc.lifeMax = 20000;
			npc.knockBackResist = 0f;

			npc.aiStyle = 12;

			npc.noGravity = true;
			npc.noTileCollide = true;

			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;

			npc.value = Item.buyPrice(0, 0, 5, 0);
		}
		
		public override void AI()
		{
			if (Main.player[cogLord.target].active)
			{
				// If the boss is not 'ramming'.
				if (npc.ai[1] == 1)
				{
					npc.rotation = Helper.rotateBetween2Points(npc.Center, Main.player[cogLord.target].Center);
					if (Main.netMode != 1 && npc.ai[2]++ >= shootRate)
					{
						Shoot();
						npc.ai[2] = 0;
					}
				}
			}

			npc.dontTakeDamage = NPC.AnyNPCs(mod.NPCType<CogLordProbe>());

			Vector2 CogLordCenter = cogLord.Center;
			Vector2 Distance = npc.Center - CogLordCenter;
			if (Distance.Length() >= MaxDist)
			{
				Distance.Normalize();
				Distance *= MaxDist;
				npc.Center = CogLordCenter + Distance;
			}
		}

		void Shoot()
		{
			if (cogLord.target != -1)
			{
				Vector2 velocity = Helper.VelocityToPoint(npc.Center, Main.player[cogLord.target].Center, ShootSpeed);
				for (int l = 0; l < 2; l++)
				{
					velocity.X = velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
					velocity.Y = velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;
					int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, ShootType, ShootDamage, ShootKN);
					Main.projectile[i].hostile = true;
					Main.projectile[i].friendly = false;
				}
			}
		}

		public override bool PreNPCLoot() => false;
		public override bool CheckActive() => !(cogLord.type == mod.NPCType<CogLord>() && cogLord.active);

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CogLordGun"), 1f);
		}
	}
}