using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Dinictis : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dinichthys");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 800;
			npc.damage = 95;
			npc.defense = 20;
			npc.knockBackResist = 0.3f;
			npc.width = 34;
			npc.height = 48;
			animationType = 65;
			npc.aiStyle = 16;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit31;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 7, 9);
			banner = npc.type;
			bannerItem = mod.ItemType("DinictisBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for(int i = 0; i < 3; ++i)
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/DinictisGore{i+1}"), 1f);
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(35) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<Sharking>());
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Main.tileSand[spawnInfo.spawnTileType] && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.water && Main.hardMode && spawnInfo.spawnTileY < Main.rockLayer && (spawnInfo.spawnTileX < 250 || spawnInfo.spawnTileX > Main.maxTilesX - 250) && !spawnInfo.playerSafe ? 0.01f : 0f;
	}
}