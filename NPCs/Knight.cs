using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadHead]
	public class Knight : ModNPC
	{
		public override string Texture => "Tremor/NPCs/Knight";

		public override string[] AltTextures => new[] { "Tremor/NPCs/Knight" };

		public override bool Autoload(ref string name)
		{
			name = "Knight";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Knight");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 1000;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 30;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 30;
			npc.height = 44;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.GoblinTinkerer;
		}


		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			return true;
		}


		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(5))
			{
				case 0:
					return "Wheatly";
				case 1:
					return "Daniel";
				case 2:
					return "Crox";
				case 3:
					return "Geralt";
				case 4:
					return "Roland";
				case 5:
					return "Rishel";
				default:
					return "Hodor";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(6))
			{
				case 0:
					return "Well met, brave adventurer.";
				case 1:
					return "A balanced weapon can mean the difference between victory and defeat.";
				case 2:
					return "I am not overly fond of the bovine hordes. Best to leave them alone really.";
				case 3:
					return "Do you have a weapon? Needs about 20% more coolness!";
				case 4:
					return "Hail and good morrow my Liege!";
				case 5:
					return "I was in a strange castle one day. There were mechanical things saying EXTERMINATE. Were they your minions?";
				default:
					return "Have you ever met a knight whose name is Sir Uncle Slime? He is best friend of mine.";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Lang.inter[28].Value;
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(mod.ItemType("ThrowingAxe"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("RustySword"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("RipperKnife"));
			nextSlot++;
			if (NPC.downedBoss1)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("TombRaider"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("SpikeShield"));
				nextSlot++;
			}
			if (NPC.downedBoss2)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("TwilightHorns"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("ToxicRazorknife"));
				nextSlot++;
			}
			if (NPC.downedBoss3)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("NecromancerClaymore"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("Shovel"));
				nextSlot++;
			}
			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("GoldenThrowingAxe"));
				nextSlot++;
			}
			if (NPC.downedMechBossAny)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("PrizmaticSword"));
				nextSlot++;
			}
			if (Main.hardMode && Main.bloodMoon)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("Oppressor"));
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 25;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = mod.ProjectileType("ThrowingAxe");
			attackDelay = 4;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/KnightGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/KnightGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/KnightGore3"), 1f);
			}
		}
	}
}