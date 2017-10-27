using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;
using Tremor.Items.Ancient;

namespace Tremor.NPCs
{
	public class FallenWarrior3 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fallen Warrior");
			Main.npcFrameCount[npc.type] = 15;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1500;
			npc.damage = 130;
			npc.defense = 62;
			npc.knockBackResist = 0.05f;
			npc.width = 32;
			npc.height = 50;
			animationType = 21;
			npc.aiStyle = 3;
			aiType = 273;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 8, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("FallenWarriorBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				npc.NewItem(mod.ItemType<AncientArmorPlate>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FWGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FWGore4"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneDungeon && NPC.downedMoonlord && Main.hardMode && spawnInfo.spawnTileY > Main.rockLayer ? 0.01f : 0f;
	}
}