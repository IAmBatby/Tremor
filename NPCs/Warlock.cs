using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	[AutoloadHead]
	public class Warlock : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "Tremor/NPCs/Warlock";
			}
		}

		public override string[] AltTextures
		{
			get
			{
				return new string[] { "Tremor/NPCs/Warlock" };
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Warlock";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Warlock");
			Main.npcFrameCount[npc.type] = 26;
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
			npc.width = 40;
			npc.height = 52;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (NPC.downedBoss2)
				return true;
			return false;
		}



		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Azazel";
				case 1:
					return "Baphomet";
				case 2:
					return "Vaal";
				case 3:
					return "Dis";
				case 4:
					return "Nisroke";
				default:
					return "Sabnak";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(6))
			{
				default:
					return "...";
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
			if (NPC.downedBoss3)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("BallnChain"));
				nextSlot++;
			}
			if (WorldGen.crimson)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ViciousHelmet"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("ViciousChestplate"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("ViciousLeggings"));
				nextSlot++;
			}

			if (!WorldGen.crimson)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("VileHelmet"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("VileChestplate"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("VileLeggings"));
				nextSlot++;
			}
			shop.item[nextSlot].SetDefaults(mod.ItemType("StrongBelt"));
			nextSlot++;
			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("Necronomicon"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("Zephyrhorn"));
				nextSlot++;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("NecroWarhammer"));
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
			projType = 270;
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
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WarlockGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WarlockGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WarlockGore3"), 1f);
			}
		}
	}
}