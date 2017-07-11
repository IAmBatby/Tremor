using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class Zarprute : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zarprute");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1500;
			npc.damage = 70;
			npc.defense = 8;
			npc.knockBackResist = 0.3f;
			npc.width = 92;
			npc.height = 54;
			animationType = 75;
			npc.aiStyle = 14;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit35;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath57;
			npc.value = Item.buyPrice(0, 0, 20, 80);
			banner = npc.type;
			bannerItem = mod.ItemType("ZarpruteBanner");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZarpruteGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZarpruteGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZarpruteGore2"), 1f);
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y + 15, mod.NPCType("Zarprite"));
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("Zarprite"));
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 15, mod.NPCType("Zarprite"));
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (Tremor.NoZoneAllowWater(spawnInfo)) && Main.hardMode && y > Main.rockLayer ? 0.01f : 0f;
		}
	}
}