using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadHead]
	public class Alchemist : ModNPC
	{
		public override string Texture => "Tremor/NPCs/Alchemist";

		public override string[] AltTextures => new[] { "Tremor/NPCs/Alchemist" };


		public override bool Autoload(ref string name)
		{
			name = "Alchemist";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist");
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
			if (NPC.downedBoss1)
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
					return "Rizo";
				case 1:
					return "Albert";
				case 2:
					return "Bernando";
				case 3:
					return "Seefeld";
				case 4:
					return "Raymond";
				case 5:
					return "Paracelsus";
				default:
					return "Nerxius";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(6))
			{
				case 0:
					return "Love is just a chain of chemical reactions. So that you know.";
				case 1:
					return "If you wanna know, it was hard to press these gel cubes.";
				case 2:
					return "Wanna try something new? I think you may be interested in... BOOM FLASKS! ";
				case 3:
					return "The man who passes the sentence should throw the flask...";
				case 4:
					return "I'm gonna have to throw EVERY SINGLE FLASK in this house!";
				case 5:
					return "What? You don't like my hairstyle? Your isn't better.";
				default:
					return "If you think that I'm a terrorist just because I sell exploding flasks? You're wrong. There are even worse people who sell worse things.";
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
			shop.item[nextSlot].SetDefaults(mod.ItemType("BasicFlask"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("HazardousChemicals"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.StinkPotion);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.LovePotion);
			nextSlot++;
			if (NPC.downedBoss2)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("Nitro"));
				nextSlot++;
			}
			if (TremorWorld.downedBoss[TremorWorld.Boss.Alchemaster])
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("Pyro"));
				nextSlot++;
			}
			if (!Main.hardMode && Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("LesserHealingFlack"));
				nextSlot++;
			}
			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ConcentratedTincture"));
				nextSlot++;
			}
			if (Main.hardMode && Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("BigHealingFlack"));
				nextSlot++;
			}
			if (!Main.hardMode && !Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("LesserManaFlask"));
				nextSlot++;
			}
			if (Main.hardMode && !Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("BigManaFlask"));
				nextSlot++;
			}
			if (Main.netMode == 1)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("HealthSupportFlask"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("ManaSupportFlask"));
				nextSlot++;
			}
			if (Main.player[Main.myPlayer].ZoneSnow)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("FreezeFlask"));
				nextSlot++;
			}
			if (Main.player[Main.myPlayer].ZoneJungle)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("LesserPoisonFlask"));
				nextSlot++;
			}
			if (NPC.downedBoss1)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("BoomFlask"));
				nextSlot++;
			}
			if (NPC.downedBoss2)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("BurningFlask"));
				nextSlot++;
			}
			if (NPC.downedBoss3)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("GoldFlask"));
				nextSlot++;
			}
			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("LesserVenomFlask"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("BlackCauldron"));
				nextSlot++;
			}
			if (NPC.downedGolemBoss)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("CthulhuBlood"));
				nextSlot++;
			}
			if (NPC.downedPlantBoss && Main.bloodMoon)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("AlchemistGlove"));
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
			projType = mod.ProjectileType("BasicFlaskPro");
			attackDelay = 5;
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
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AlchemistGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AlchemistGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AlchemistGore3"), 1f);
			}
		}
	}
}