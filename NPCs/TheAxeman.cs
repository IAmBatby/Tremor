using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class TheAxeman : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Axeman");
			Main.npcFrameCount[npc.type] = 16;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 4000;
			npc.damage = 155;
			npc.defense = 88;
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
			banner = npc.type;
			bannerItem = mod.ItemType("TheAxemanBanner");
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
				Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheAxemanGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheAxemanGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheAxemanGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheAxemanGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheAxemanGore3"), 1f);

				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Main.tileSand[spawnInfo.spawnTileType] && spawnInfo.water && spawnInfo.spawnTileY < Main.rockLayer && (spawnInfo.spawnTileX < 250 || spawnInfo.spawnTileX > Main.maxTilesX - 250) && !spawnInfo.playerSafe && NPC.downedMoonlord && Main.eclipse ? 0.01f : 0f;
	}
}