using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class Woody : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Woody");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 40;
			npc.damage = 18;
			npc.defense = 13;
			npc.knockBackResist = 0.3f;
			npc.width = 56;
			npc.height = 30;
			animationType = 141;
			npc.aiStyle = 1;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 2, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("WoodyBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodyGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodyGore2"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.player.ZoneJungle && spawnInfo.spawnTileY > Main.rockLayer ? 0.01f : 0f;
	}
}