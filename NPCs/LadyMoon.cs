using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadHead]
	public class LadyMoon : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "Tremor/NPCs/LadyMoon";
			}
		}

		public override string[] AltTextures
		{
			get
			{
				return new string[] { "Tremor/NPCs/LadyMoon" };
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Lady Moon";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lady Moon");
			Main.npcFrameCount[npc.type] = 21;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 2;
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
			npc.height = 48;
			npc.aiStyle = 7;
			npc.damage = 20;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Dryad;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (NPC.downedMoonlord)
			{
				return true;
			}
			return false;
		}


		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Atria";
				case 1:
					return "Mintaka";
				case 2:
					return "Nashira";
				case 3:
					return "Rana";
				case 4:
					return "Talita";
				case 5:
					return "Zosma";
				default:
					return "Pleyona";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(6))
			{
				case 0:
					return "There are so many beautiful things in this world! What can be more beautiful than a big shining star? Maybe only an exploding big shining star!";
				case 1:
					return "I hope this world don't have crazy kings who wanna kill you? Aren't you one of them!?";
				case 2:
					return "I have heard about an space station called Death Star that can destroy any planet or star! Can you show me this station? ";
				case 3:
					return "I believe I can fly! I believe I can touch the sk-... Sorry, I forgot that I'm not alone here!";
				case 4:
					return "How are you going to call a man that watches an exploding star? A STARk man!";
				default:
					return "Planets are burning, stars are exploding, but my prices for my spacy things are not changing! ";
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
			shop.item[nextSlot].SetDefaults(mod.ItemType("DimensionalTopHat"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("ExtraterrestrialRubies"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("UnchargedBand"));
			nextSlot++;
			if (!Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ManaBooster"));
				nextSlot++;
			}
			if (Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("HealthBooster"));
				nextSlot++;
			}
			if (Main.bloodMoon)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ChainedRocket"));
				nextSlot++;
			}
			if (Main.eclipse)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("Infusion"));
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 165;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = 12;
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
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FarmerGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FarmerGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FarmerGore3"), 1f);
			}
		}
	}
}