using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadHead]
	public class Elf : ModNPC
	{
		public override string Texture => "Tremor/NPCs/Elf";

		public override string[] AltTextures => new[] { "Tremor/NPCs/Elf" };

		public override bool Autoload(ref string name)
		{
			name = "Elf";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elf");
			Main.npcFrameCount[npc.type] = 26;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 6;
			NPCID.Sets.DangerDetectRange[npc.type] = 1000;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 30;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 36;
			npc.height = 44;
			npc.aiStyle = 7;
			npc.damage = 20;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					for (int j = 0; j < player.inventory.Length; j++)
					{
						if (player.inventory[j].type == mod.ItemType("SuspiciousLookingPresent"))
						{
							return true;
						}
					}
				}
			}
			return false;
		}


		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Nick";
				case 1:
					return "Elfie";
				case 2:
					return "Jingle";
				case 3:
					return "Chippy";
				case 4:
					return "Sparkle";
				case 5:
					return "Twinkle";
				case 6:
					return "Elvis";
				case 7:
					return "Peppermint";
				default:
					return "Snowflake";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(6))
			{
				case 0:
					return "What do you know about reindeers?";
				case 1:
					return "I can give you some presents but... You've been naughty this year.";
				case 2:
					return "I am Santa's favorite elf!";
				case 3:
					return "Jingle bells, jingle bells, jingle all the way!";
				case 4:
					return "Someone threw a snowball at me. I don't know who did it but I will find him and throw a snowball at him too.";
				default:
					return "I licked an icicle one fine day. It resulted in not much fun.";
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
			shop.item[nextSlot].SetDefaults(mod.ItemType("RedChristmasStocking"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("BlueChristmasStocking"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("GreenChristmasStocking"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("CandyCane"));
			nextSlot++;
			if (NPC.downedBoss1)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("SnowShotgun"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("CandyBow"));
				nextSlot++;
			}
			if (NPC.downedBoss3)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("TheSnowBall"));
				nextSlot++;
			}
			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("Blizzard"));
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = 1;
			attackDelay = 2;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}