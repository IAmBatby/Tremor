using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs.Bosses.CogLord
{
	public class GogLordGog : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Gear");
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1;
			npc.damage = 100;
			npc.defense = 0;
			npc.knockBackResist = 1f;
			npc.width = 42;
			npc.height = 46;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.dontTakeDamage = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath10;
			npc.value = Item.buyPrice(0, 1, 0, 0);

			npc.alpha = 244;
			npc.scale = 0.25F;
		}
		
		public override bool PreAI()
		{
			if(npc.ai[0] == 0) // First update/spawn sequence.
			{
				npc.localAI[0] = Main.rand.NextBool() ? -Main.rand.Next(1, 11) : Main.rand.Next(1, 11);
				npc.ai[0] = 1;
			}
			else if (npc.ai[0] == 1) // 'Appear' sequence.
			{
				if(npc.scale < 1)
					npc.scale += 0.75F / 60;
				else
					npc.scale = 1;

				if ((npc.alpha -= 4) <= 0)
				{
					if (npc.ai[1]++ >= 120)
					{
						npc.scale = 1;
						npc.ai[0] = 2;
					}
					npc.alpha = 0;
				}
			}
			else if (npc.ai[0] == 2) // 'Disappear' sequence.
			{
				npc.scale -= 0.75F / 60;
				if ((npc.alpha += 4) >= 255)
				{
					npc.life = -1;
					npc.active = false;
					npc.checkDead();
				}
			}

			npc.velocity *= Vector2.Zero;
			npc.rotation += (npc.localAI[0] * 0.05F) / npc.Opacity;
			return false;
		}

		public override bool CanHitPlayer(Player target, ref int cooldownSlot)
		{
			return npc.alpha <= 125;
		}
	}
}