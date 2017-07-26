using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadHead]
	public class Startrooper : ModNPC
	{
		public override string Texture => "Tremor/NPCs/Startrooper";

		public override string[] AltTextures => new[] { "Tremor/NPCs/Startrooper" };

		public override bool Autoload(ref string name)
		{
			name = "Startrooper";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Startrooper");
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
			if (TremorWorld.Boss.SpaceWhale.Downed())
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
					return "Ripley";
				case 1:
					return "Dallas";
				case 2:
					return "Brett";
				case 3:
					return "Kane";
				case 4:
					return "Ash";
				case 5:
					return "Parker";
				default:
					return "Lambert";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(6))
			{
				case 0:
					return "There is an explanation for anything, you know.";
				case 1:
					return "If you get into a trouble remember that somebody will surely save your skin.";
				case 2:
					return "My friend always liked to tell me the odds but now he is dead. You should know: Never tell me the odds.";
				case 3:
					return "That giant flying fish that you've defeated was making plans to destroy my home-planet. Glad you've killed him.";
				case 4:
					return "I suggest you carrying at least small blaster - nobody knows what's on mind of this creatures in this world.";
				case 5:
					return "Have you ever heard a tale of a giant three eyed creature with eyes in it hands and tentacles on head? I'm very glad that it is just a stupid story.";
				default:
					return "There were some cult of men calling themselve knights and fighting with some kind of light swords on a planet I was travelling once to. As for me, a gun is better than a useless sword.";
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
			shop.item[nextSlot].SetDefaults(mod.ItemType("Starmine"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("ChainBow"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("EnforcerShield"));
			nextSlot++;
			if (!Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("SniperHelmet"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("SniperBreastplate"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("SniperBoots"));
				nextSlot++;
			}
			if (Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ParatrooperLens"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("StartrooperFlameburstPistol"));
				nextSlot++;
			}
			if (TremorWorld.Boss.Trinity.Downed())
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("WartimeRocketLauncher"));
				nextSlot++;
			}
			if (TremorWorld.Boss.Trinity.Downed() && !Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("CosmicAssaultRifle"));
				nextSlot++;
			}
			if (Main.bloodMoon)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ParatrooperShotgun"));
				nextSlot++;
			}
			if (Main.player[Main.myPlayer].HasItem(mod.ItemType("SuperBigCannon")))
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("SBCCannonballAmmo"), false);
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 310;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 15;
			randExtraCooldown = 15;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = mod.ProjectileType("StarminePro");
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
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StartrooperNGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StartrooperNGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StartrooperNGore3"), 1f);
			}
		}
	}
}