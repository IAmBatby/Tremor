using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class TheGirl : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Girl");
			Main.npcFrameCount[npc.type] = 9;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 3000;
			npc.damage = 175;
			npc.defense = 48;
			npc.knockBackResist = 0.3f;
			npc.width = 34;
			npc.height = 54;
			animationType = 529;
			npc.aiStyle = 3;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			aiType = 529;
			npc.DeathSound = SoundID.NPCDeath52;
			npc.value = Item.buyPrice(0, 3, 1, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("TheGirlBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(5))
				this.NewItem(mod.ItemType<BrokenHeroArmorplate>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Main.tileSand[spawnInfo.spawnTileType] && spawnInfo.water && spawnInfo.spawnTileY < Main.rockLayer && (spawnInfo.spawnTileX < 250 || spawnInfo.spawnTileX > Main.maxTilesX - 250) && !spawnInfo.playerSafe && NPC.downedMoonlord && Main.eclipse ? 0.01f : 0f;
	}
}