using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class Quetzalcoatl : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quetzalcoatl");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 3000;
			npc.damage = 170;
			npc.defense = 73;
			npc.knockBackResist = 1f;
			npc.width = 32;
			npc.height = 62;
			animationType = 62;
			npc.aiStyle = 14;
			//aiType = 226;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath10;
			npc.value = Item.buyPrice(0, 6, 1, 0);
			npc.noTileCollide = true;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/QGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/QGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/QGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/QGore3"), 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 59, hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}
	}
}