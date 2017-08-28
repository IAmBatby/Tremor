using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class PossessedHornet2 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Possessed Hornet");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1500;
			npc.noGravity = true;
			npc.damage = 132;
			npc.defense = 68;
			npc.knockBackResist = 0.05f;
			npc.width = 32;
			npc.height = 40;
			animationType = 176;
			npc.aiStyle = 5;
			aiType = 176;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.value = Item.buyPrice(0, 0, 10, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("PossessedHornetBanner");
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

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PHGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PHGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PHGore4"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		   => Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.player.ZoneJungle && NPC.downedMoonlord && Main.hardMode && spawnInfo.spawnTileY > Main.rockLayer ? 0.01f : 0f;
	}
}