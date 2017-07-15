using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadHead]
	public class ArabianMerchant : ModNPC
	{
		public override string Texture => "Tremor/NPCs/ArabianMerchant";

		public override string[] AltTextures => new[] { "Tremor/NPCs/ArabianMerchant" };

		public override bool Autoload(ref string name)
		{
			name = "Arabian Merchant";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arabian Merchant");
			Main.npcFrameCount[npc.type] = 26;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 5;
			NPCID.Sets.DangerDetectRange[npc.type] = 1000;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 30;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
		}
		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 28;
			npc.height = 48;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			//npc.homeless = true;
			//npc.active = false;
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (TremorWorld.downedBoss[TremorWorld.DownedBoss.Rukh])
			{
				return true;
			}
			return false;
		}

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(5))
			{
				case 0:
					return "Badruddin";
				case 1:
					return "Galib";
				case 2:
					return "Salavat";
				case 3:
					return "Zafar";
				case 4:
					return "Valid";
				case 5:
					return "Tunak";
				default:
					return "Nadim";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(6))
			{
				case 0:
					return "Salam aleykum! Do you need anything?";
				case 1:
					return "I got some sand in my pockets. I think throwing it will hurt your eyes.";
				case 2:
					return "My wear was absolutely white long time ago. Maybe I should wash it with this perfect yellow water?";
				case 3:
					return "There are stories about what happened in the sands of this desert. But I won't tell you anything.";
				case 4:
					return "In case something will happen with me... I bequeath you all my sand.";
				case 5:
					return "The sands are telling me that... That... Ugh... That you will buy everything!";
				default:
					return "The sands are moving... Be careful or you will be sucked into unknown depths!";
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
			shop.item[nextSlot].SetDefaults(mod.ItemType("GenieLamp"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("JavaHood"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("JavaRobe"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("SandstoneRing"));
			nextSlot++;
			if (NPC.downedBoss1)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("FossilSugar"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("DesertCrown"));
				nextSlot++;
			}
			if (NPC.downedBoss2)
			{
				shop.item[nextSlot].SetDefaults(3378);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(3379);
				nextSlot++;
			}
			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("DesertEagle"));
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 30;
			knockback = 3f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = mod.ProjectileType("Sand");
			attackDelay = 4;
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WhiteTurban"));
				};
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArabianMerchantGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArabianMerchantGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArabianMerchantGore3"), 1f);
			}
		}


		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}