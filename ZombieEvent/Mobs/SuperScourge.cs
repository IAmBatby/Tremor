using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Mobs
{

	public class SuperScourge : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scourge");
			Main.npcFrameCount[npc.type] = 10;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 500;
			npc.damage = 120;
			npc.defense = 120;
			npc.knockBackResist = 0.3f;
			npc.width = 56;
			npc.height = 48;
			animationType = 429;
			aiType = 429;
			npc.aiStyle = 3;
			npc.npcSlots = 0.2f;
			npc.scale *= 0.8f;
			npc.HitSound = SoundID.NPCHit37;
			npc.DeathSound = SoundID.NPCDeath33;
			npc.value = Item.buyPrice(0, 0, 9, 9);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("ScourgeBanner");
		}

		public override void AI()
		{
			if (!NPC.AnyNPCs(mod.NPCType("Cryptomage")))
			{
				npc.Transform(mod.NPCType("Scourge"));
			}
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(30) == 0 && !WorldGen.crimson)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedCleaver"));
				};
				if (Main.rand.Next(30) == 0 && WorldGen.crimson)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IchorCleaver"));
				};
				if (Main.rand.NextBool(3))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedCloth"), Main.rand.Next(1, 3));
				};
			}
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(5))
			{
				player.AddBuff(153, 600, true);
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, 99, 0.8f);
				Gore.NewGore(npc.position, npc.velocity, 99, 0.8f);
				Gore.NewGore(npc.position, npc.velocity, 99, 0.8f);
				Gore.NewGore(npc.position, npc.velocity, 99, 0.8f);
				Gore.NewGore(npc.position, npc.velocity, 99, 0.8f);

				NPC.NewNPC((int)npc.position.X + 50, (int)npc.position.Y - 48, mod.NPCType("Dopelganger"));
				NPC.NewNPC((int)npc.position.X + 25, (int)npc.position.Y - 48, mod.NPCType("Dopelganger"));
				NPC.NewNPC((int)npc.position.X - 50, (int)npc.position.Y - 48, mod.NPCType("Dopelganger"));
				NPC.NewNPC((int)npc.position.X - 25, (int)npc.position.Y - 48, mod.NPCType("Dopelganger"));
			}
		}

	}
}