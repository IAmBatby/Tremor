using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class CreatorofNightmares : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Creator of Nightmares");
			Main.npcFrameCount[npc.type] = 16;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 6000;
			npc.damage = 155;
			npc.defense = 38;
			npc.knockBackResist = 0.3f;
			npc.width = 34;
			npc.height = 54;
			animationType = 460;
			npc.aiStyle = 3;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			aiType = 604;
			npc.DeathSound = SoundID.NPCDeath52;
			npc.value = Item.buyPrice(0, 3, 1, 0);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("CreatorofNightmaresBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(5) == 0)
				npc.NewItem(mod.ItemType<BrokenHeroArmorplate>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);

				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && spawnInfo.spawnTileY < Main.rockLayer && NPC.downedMoonlord && Main.eclipse ? 0.01f : 0f;
	}
}