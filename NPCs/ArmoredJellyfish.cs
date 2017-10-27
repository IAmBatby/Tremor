using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class ArmoredJellyfish : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Armored Jellyfish");
			Main.npcFrameCount[npc.type] = 7;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 40;
			npc.damage = 12;
			npc.defense = 20;
			npc.knockBackResist = 0.3f;
			npc.width = 62;
			npc.height = 46;
			animationType = 242;
			npc.aiStyle = 18;
			npc.npcSlots = 0.7f;
			npc.HitSound = SoundID.NPCHit47;
			npc.DeathSound = SoundID.NPCDeath23;
			npc.value = Item.buyPrice(0, 0, 6, 3);
			banner = npc.type;
			bannerItem = mod.ItemType("ArmoredJellyfishBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArmoredGore"), 1f);
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RottenChunk);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.player.ZoneCorrupt && spawnInfo.spawnTileY > Main.rockLayer ? 0.05f : 0f;
		}
	}
}