using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.NPCs
{

	public class NovaAlchemistC : ModNPC
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Alchemist");
			Main.npcFrameCount[npc.type] = 4;
		}

		//Int variables
		int AnimationRate = 8;
		int CountFrame;
		int TimeToAnimation = 8;
		int Timer;
		public override void SetDefaults()
		{
			npc.lifeMax = 1;
			npc.damage = 200;
			npc.defense = 50;
			npc.knockBackResist = 0.4f;
			npc.width = 34;
			npc.height = 56;
			npc.aiStyle = 3;
			aiType = NPCID.AngryBones;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit55;
			npc.DeathSound = SoundID.NPCDeath51;
			npc.dontTakeDamage = true;
			npc.alpha = 150;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.damage = 350;
		}

		public override void AI()
		{
			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
			npc.rotation = 0f;
			NovaAnimation();
			Timer++;
			if (Timer >= 350)
			{
				npc.life = -1;
				npc.active = false;
				npc.checkDead();
				for (int k = 0; k < 19; k++)
				{
					Vector2 Vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					Vector.Normalize();
					Vector *= Main.rand.Next(10, 201) * 0.01f;
					int i = Projectile.NewProjectile(npc.position.X, npc.position.Y, Vector.X, Vector.Y, mod.ProjectileType("NovaAlchemistCloud"), 20, 1);
					Main.projectile[i].friendly = false;
				}
			}
		}

		void NovaAnimation()
		{
			if (--TimeToAnimation <= 0)
			{
				if (++CountFrame > 3)
					CountFrame = 1;
				TimeToAnimation = AnimationRate;
				npc.frame = GetFrame(CountFrame + 0);
			}
		}

		Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, npc.frame.Height * (Number - 1), npc.frame.Width, npc.frame.Height);
		}
	}
}