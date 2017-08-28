using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class MushroomCreature : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mushroom Creature");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 80;
			npc.damage = 22;
			npc.defense = 5;
			npc.knockBackResist = 0.3f;
			npc.width = 38;
			npc.height = 50;
			animationType = 75;
			npc.aiStyle = 3;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit40;
			npc.DeathSound = SoundID.NPCDeath24;
			npc.value = Item.buyPrice(0, 0, 3, 20);
			banner = npc.type;
			aiType = 21;
			bannerItem = mod.ItemType("MushroomCreatureBanner");
		}

		public override void AI()
		{ 
			if (Main.rand.Next(1000) == 0)
				Main.PlaySound(22, (int)npc.position.X, (int)npc.position.Y, 1);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && spawnInfo.spawnTileType == TileID.MushroomGrass && spawnInfo.spawnTileY < Main.rockLayer ? 0.03f : 0f;
	}
}