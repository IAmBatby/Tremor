using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Invasion;

namespace Tremor.Invasion
{
	[AutoloadBossHead]
	public class Titan_ : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titan Soul");
			Main.npcFrameCount[npc.type] = 4;
		}

		public static readonly int arenaWidth = (int)(1.3f * NPC.sWidth);
		public override void SetDefaults()
		{
			npc.aiStyle = 94;
			npc.lifeMax = 1;
			npc.dontTakeDamage = true;
			npc.defense = 15;
			npc.knockBackResist = 0f;
			npc.width = 108;
			npc.height = 98;
			npc.value = Item.buyPrice(0, 20, 0, 0);
			npc.npcSlots = 15f;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
		}

		int CurrentFrame = 0;
		int TimeToAnimation = 6;
		const int AnimationRate = 6;
		bool FirstState_ = true;
		void Animation()
		{
			if (--TimeToAnimation <= 0)
			{

				if (++CurrentFrame > 4)
					CurrentFrame = 1;
				TimeToAnimation = AnimationRate;
				npc.frame = GetFrame(CurrentFrame + ((FirstState_) ? 0 : 4));
			}
		}

		Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, npc.frame.Height * (Number - 1), npc.frame.Width, npc.frame.Height);
		}







		public override void HitEffect(int hitDirection, double damage)
		{

		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return false;
		}

		public override void AI()
		{
			Player player = Main.player[Main.myPlayer];
			if (npc.Distance(Main.player[npc.target].position) > 5000)
			{
				player.position = npc.Center;
			}
			Animation();
			CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
			if (InvasionWorld.CyberWrath && InvasionWorld.CyberWrathPoints1 == 97)
			{
				npc.dontTakeDamage = false;
				npc.life = 0;
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("Titan"));
				InvasionWorld.CyberWrathPoints1 = 98;
			}

			if (InvasionWorld.CyberWrath && InvasionWorld.CyberWrathPoints1 < 98)
				npc.dontTakeDamage = true;
			bool FirstAttack = true;
			if (FirstAttack)
			{
				SetupCrystals(arenaWidth / 2, false);
				FirstAttack = false;
			}


			if (player.dead)
			{
				npc.active = true;
			}

			if (player.statLife == 0)
			{
				player.position = npc.Center;
			}
		}

		private void SetupCrystals(int radius, bool clockwise)
		{
			if (Main.netMode == 1)
			{
				return;
			}
			Vector2 center = npc.Center;
			for (int k = 0; k < 15; k++)
			{
				float angle = 2f * (float)Math.PI / 10f * k;
				Vector2 pos = center + radius * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
				int damage = 80;
				if (Main.expertMode)
				{
					damage = (int)(100 / Main.expertDamage);
				}
				int proj = Projectile.NewProjectile(pos.X, pos.Y, 0f, 0f, mod.ProjectileType("TitanCrystal_"), damage, 0f, Main.myPlayer, npc.whoAmI, angle);
				Main.projectile[proj].localAI[0] = radius;
				Main.projectile[proj].localAI[1] = clockwise ? 1 : -1;
				//NetMessage.SendData(27, -1, -1, "", proj);
			}
		}
	}
}