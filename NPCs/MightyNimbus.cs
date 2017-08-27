using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class MightyNimbus : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mighty Nimbus");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 4000;
			npc.damage = 160;
			npc.defense = 70;
			npc.knockBackResist = 0.1f;
			npc.width = 70;
			npc.height = 50;
			animationType = 250;
			npc.aiStyle = 49;
			aiType = 250;
			npc.noGravity = true;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit30;
			npc.buffImmune[20] = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[39] = true;
			npc.buffImmune[31] = false;
			npc.DeathSound = SoundID.NPCDeath33;
			npc.value = Item.buyPrice(0, 0, 7, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("MightyNimbusBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 2f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 2f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 3f);

				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 76, 0f, 0f, 200, npc.color, 1f);
			}
		}

		public override void AI()
		{
			if (Main.netMode != 1 && Main.rand.Next(1000) == 0)
			{
				NPC.NewNPC((int)npc.position.X - 50, (int)npc.position.Y, NPCID.AngryNimbus);
				NPC.NewNPC((int)npc.position.X + 50, (int)npc.position.Y, NPCID.AngryNimbus);
			}

			if (Main.rand.Next(700) == 0)
				Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, Main.rand.Next(41, 44));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && NPC.downedMoonlord && Helper.NoZoneAllowWater(spawnInfo) && Main.raining && spawnInfo.spawnTileY < Main.worldSurface ? 0.01f : 0f;
	}
}