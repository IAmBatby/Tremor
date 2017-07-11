using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadHead]
	public class Professor : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "Tremor/NPCs/Professor";
			}
		}

		public override string[] AltTextures
		{
			get
			{
				return new string[] { "Tremor/NPCs/Professor" };
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Professor";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Professor");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 1000;
			NPCID.Sets.AttackType[npc.type] = 1;
			NPCID.Sets.AttackTime[npc.type] = 30;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 24;
			npc.height = 46;
			npc.aiStyle = 7;
			npc.damage = 40;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.GoblinTinkerer;
		}

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(5))
			{
				case 0:
					return "James";
				case 1:
					return "Harold";
				case 2:
					return "Steven";
				case 3:
					return "David";
				case 4:
					return "John";
				case 5:
					return "Brus Bunner";
				default:
					return "Alfred";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(6))
			{
				case 0:
					return "Don't pay attention to my appearance. This is just the result of a failed experiment.";
				case 1:
					return "What do you have? Carrot? Oh, never mind.";
				case 2:
					return "Imagine that in all those rabbits that you have killed were imprisoned soul of common people! Just think about it.";
				case 3:
					return "Someday we'll all get into the warm embrace of death. Bring me some more carrot soup before this happens.";
				case 4:
					return "Magic allows you to do what cannot be done scientifically. The main thing is not to overdo it, if you know what I mean.";
				case 5:
					return "I  don't like people that like how wizards get rabbits out of their magic hats. It's horrible!";
				default:
					return "I studied the anomalies in this world long time ago. Exactly during this I became the anomaly myself. Funny.";
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (Main.hardMode)
				return true;
			return false;
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
			shop.item[nextSlot].SetDefaults(mod.ItemType("KeyMold"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("LifeMachine"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("AncientTechnology"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("BagofDust"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(1337);
			nextSlot++;

			if (NPC.downedAncientCultist)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ManaGenerator"));
				nextSlot++;
			}
			if (NPC.downedMechBossAny)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ChaoticAmplifier"));
				nextSlot++;
			}

		}


		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 40;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 5;
			randExtraCooldown = 5;
		}

		public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
		{
			scale = 1f;
			item = mod.ItemType("AlienBlaster");
			closeness = 14;
		}
		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)//Allows you to determine the projectile type of this town NPC's attack, and how long it takes for the projectile to actually appear
		{
			projType = 440;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)//Allows you to determine the speed at which this town NPC throws a projectile when it attacks. Multiplier is the speed of the projectile, gravityCorrection is how much extra the projectile gets thrown upwards, and randomOffset allows you to randomize the projectile's velocity in a square centered around the original velocity
		{
			multiplier = 7f;
			// randomOffset = 4f;

		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ProfessorGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ProfessorGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ProfessorGore3"), 1f);
			}
		}
	}
}