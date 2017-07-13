using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.ZombieEvent.Items;

namespace Tremor.ZombieEvent.Mobs
{
	public class DiceZombie : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dice Zombie");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 300;
			npc.damage = 22;
			npc.defense = 26;
			npc.knockBackResist = 0.3f;
			npc.width = 34;
			npc.height = 46;
			animationType = 3;
			npc.aiStyle = 3;
			npc.npcSlots = 2f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 1);
			banner = npc.type;
			bannerItem = mod.ItemType("DiceZombieBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeadlingHead1"));
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeadlingLeg"));
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeadlingArm"));
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeadlingLeg"));
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeadlingArm"));
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DiceGore1"));
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DiceGore2"));
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DiceGore3"));
			}
		}


		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<Rupicide>(), Main.rand.Next(1, 3));
			};

			if (Main.rand.Next(5) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<StoneDice>());
			};
		}
	}
}