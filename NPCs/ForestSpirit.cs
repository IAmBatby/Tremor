using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class ForestSpirit : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forest Spirit");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 180;
			npc.damage = 15;
			npc.defense = 10;
			npc.knockBackResist = 0.3f;
			npc.width = 34;
			npc.height = 48;
			animationType = 316;
			npc.aiStyle = 22;
			npc.npcSlots = 0.4f;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit44;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath58;
			npc.value = Item.buyPrice(0, 0, 4, 15);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("ForestSpiritBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && NPC.downedBoss2 && !Main.dayTime && spawnInfo.spawnTileY < Main.worldSurface ? 0.1f : 0f;
	}
}
