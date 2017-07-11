using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadHead]
	public class ForgeMaster : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "Tremor/NPCs/ForgeMaster";
			}
		}

		public override string[] AltTextures
		{
			get
			{
				return new string[] { "Tremor/NPCs/ForgeMaster" };
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Forge Master";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forge Master");
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
			npc.width = 28;
			npc.height = 48;
			npc.aiStyle = 7;
			npc.damage = 10;
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
						if (player.inventory[j].type == mod.ItemType("JungleAlloy"))
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
			switch (WorldGen.genRand.Next(5))
			{
				case 0:
					return "Gefest";
				case 1:
					return "Aule";
				case 2:
					return "Agarorn";
				case 3:
					return "Treak";
				case 4:
					return "Haymer";
				default:
					return "Golan";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(6))
			{
				case 0:
					return "You can't lift my hammer? Not surprising! That's because you are not worthy!";
				case 1:
					return "Strangely but nobody uses hammers for making bars. How do you just put ore into furnaces and get bars!? That is insane!";
				case 2:
					return "Valar Morghulis! Oh wait, that's not the Braavos! Forget what I've said.";
				case 3:
					return "What? You ask me who am I?! I am the son of the Vulcan and the Vulcan is the mighty anvilborn!";
				case 4:
					return "My bars are better because I make them with my hammer. If you won't buy my bars I will make a bar from you.";
				case 5:
					return "You wonder why people call me Forge Master!? What means you don't believe I'm the real Master of Forges!?";
				default:
					return "Be careful when working with forges. I got burnt once when I was taking off a bar from it. That's why I'm wearing such armor!";
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
			shop.item[nextSlot].SetDefaults(mod.ItemType("GreatAnvil"));
			nextSlot++;
			if (Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(ItemID.CopperBar);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.IronBar);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.SilverBar);
				nextSlot++;
			}
			if (!Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(ItemID.TinBar);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.LeadBar);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.TungstenBar);
				nextSlot++;
			}

			if (NPC.downedBoss2 && Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(ItemID.GoldBar);
				nextSlot++;
			}
			if (NPC.downedBoss2 && !Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(ItemID.PlatinumBar);
				nextSlot++;
			}
			if (NPC.downedBoss2)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("PoisonRod"));
				nextSlot++;
			}

			if (NPC.downedBoss3 && Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(ItemID.DemoniteBar);
				nextSlot++;
			}
			if (NPC.downedBoss3 && !Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(ItemID.CrimtaneBar);
				nextSlot++;
			}
			if (NPC.downedBoss3)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("BurningHammer"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("PerfectBehemoth"));
				nextSlot++;
			}

			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("GoldenMace"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.HellstoneBar);
				nextSlot++;
			}

			if (NPC.downedMechBossAny && Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(ItemID.CobaltBar);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.MythrilBar);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.AdamantiteBar);
				nextSlot++;
			}
			if (NPC.downedMechBossAny && !Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(ItemID.PalladiumBar);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.OrichalcumBar);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.TitaniumBar);
				nextSlot++;
			}

			if (NPC.downedPlantBoss)
			{
				shop.item[nextSlot].SetDefaults(ItemID.HallowedBar);
				nextSlot++;
			}

			if (NPC.downedGolemBoss)
			{
				shop.item[nextSlot].SetDefaults(ItemID.ChlorophyteBar);
				nextSlot++;
			}

			if (NPC.downedAncientCultist)
			{
				shop.item[nextSlot].SetDefaults(ItemID.SpectreBar);
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 22;
			knockback = 3f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = mod.ProjectileType("BurningHammerPro");
			attackDelay = 4;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BlackSmithGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BlackSmithGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BlackSmithGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BlackSmithGore4"), 1f);

			}
		}


		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}