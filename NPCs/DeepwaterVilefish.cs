using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{

	public class DeepwaterVilefish : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deepwater Vilefish");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 50;
			npc.damage = 12;
			npc.defense = 3;
			npc.knockBackResist = 0.3f;
			npc.width = 62;
			npc.height = 46;
			animationType = 241;
			npc.aiStyle = 16;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit47;
			npc.DeathSound = SoundID.NPCDeath23;
			npc.value = Item.buyPrice(0, 0, 0, 3);
			banner = npc.type;
			bannerItem = mod.ItemType("DeepwaterVilefishBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				npc.NewItem(ItemID.RottenChunk);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> spawnInfo.player.ZoneCorrupt && spawnInfo.spawnTileY > Main.rockLayer ? 0.05f : 0f;
	}
}