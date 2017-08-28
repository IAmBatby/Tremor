using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class QuartzBeetle : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quartz Beetle");
			Main.npcFrameCount[npc.type] = 12;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 3500;
			npc.damage = 140;
			npc.defense = 62;
			npc.knockBackResist = 0.05f;
			npc.width = 32;
			npc.height = 50;
			animationType = 185;
			npc.aiStyle = 3;
			aiType = 525;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit41;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.value = Item.buyPrice(0, 0, 8, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("QuartzBeetleBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				this.NewItem(mod.ItemType<PurpleQuartz>(), 2);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<Dusts.NightmareFlame>(), 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/QBGore1"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.player.ZoneJungle && NPC.downedMoonlord && Main.hardMode && spawnInfo.spawnTileY > Main.rockLayer ? 0.01f : 0f;
	}
}