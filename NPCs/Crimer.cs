using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class Crimer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimer");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 250;
			npc.damage = 70;
			npc.defense = 12;
			npc.knockBackResist = 0.5f;
			npc.width = 40;
			npc.height = 40;
			animationType = 121;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.npcSlots = 0.7f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 5, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("CrimerBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				if(Main.netMode != 1)
					NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 48, NPCID.Crimslime);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.player.ZoneCrimson && Main.hardMode && spawnInfo.spawnTileY < Main.worldSurface ? 0.02f : 0f;
	}
}