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
	public class Undertaker : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "Tremor/NPCs/Undertaker";
			}
		}

		public override string[] AltTextures
		{
			get
			{
				return new string[] { "Tremor/NPCs/Undertaker" };
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Undertaker";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Undertaker");
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
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (TremorWorld.downedTrinity)
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
					return "Tenner";
				case 1:
					return "Geyer";
				case 2:
					return "Cleve";
				case 3:
					return "Ferron";
				case 4:
					return "Gasper";
				case 5:
					return "Spots";
				default:
					return "Hargon";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(6))
			{
				case 0:
					return "Don't worry. Nobody will get out of the coffin that I have made.";
				case 1:
					return "Are you afraid of ghosts? I'm not. But the ghosts are afraid of me.";
				case 2:
					return "If you need some help then feel free to ask me. I have a lot of undead things on my side.";
				case 3:
					return "What will you prefer to do if this day will be your last day?";
				case 4:
					return "Our life is a challenge. To make it easier - buy my stuff.";
				case 5:
					return "Don't worry. I'm not a vampire even my eyes are red and my skin is of a strange color.";
				default:
					return "Do you prefer blood or tomato juice?";
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
			shop.item[nextSlot].SetDefaults(mod.ItemType("Skullheart"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("SpearofJustice"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("TheGhostClaymore"));
			nextSlot++;
			if (!Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("LivingTombstone"));
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 150;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = 645;
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
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheUndertakerGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheUndertakerGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheUndertakerGore3"), 1f);
			}
		}
	}
}