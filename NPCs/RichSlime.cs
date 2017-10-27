using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class RichSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rich Slime");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1100;
			npc.damage = 210;
			npc.defense = 45;
			npc.knockBackResist = 0.3f;
			npc.width = 32;
			npc.height = 46;
			animationType = 1;
			npc.aiStyle = 1;
			aiType = 1;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath23;
			npc.value = Item.buyPrice(1, 0, 0, 0);
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				this.NewItem(23, Main.rand.Next(5, 9));
			if (Main.rand.Next(50) == 0)
				this.NewItem(mod.ItemType<FashionableHat>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
				}

				Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 1, 2.5f * hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> spawnInfo.spawnTileY < Main.rockLayer && Main.hardMode && Helper.NoInvasion(spawnInfo) && NPC.downedMoonlord && Main.dayTime ? 0.005f : 0f;
	}
}