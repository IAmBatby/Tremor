using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class GoplitArcher : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hoplite Archer");
			Main.npcFrameCount[npc.type] = 20;
		}

		public override void SetDefaults()
		{
			npc.width = 24;
			npc.height = 44;
			npc.damage = 26;
			npc.defense = 20;
			npc.lifeMax = 95;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 3, 7);
			npc.knockBackResist = 0.2f;
			npc.aiStyle = 3;
			aiType = 111;
			animationType = 110;
			npc.buffImmune[20] = true;
			npc.buffImmune[31] = false;
			npc.buffImmune[24] = true;
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("GoplitArcherBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 31, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GoplitAGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GoplitAGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GoplitAGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GoplitAGore3"), 1f);
			}
		}

		public override void NPCLoot()
		{
			this.NewItem(mod.ItemType<StoneofLife>());
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.spawnTileType == TileID.Marble && spawnInfo.spawnTileY > Main.rockLayer ? 0.01f : 0f;
	}
}
