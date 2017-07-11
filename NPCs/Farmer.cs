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
	public class Farmer : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "Tremor/NPCs/Farmer";
			}
		}

		public override string[] AltTextures
		{
			get
			{
				return new string[] { "Tremor/NPCs/Farmer" };
			}
		}
		public override bool Autoload(ref string name)
		{
			name = "Farmer";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Farmer");
			Main.npcFrameCount[npc.type] = 23;
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
			npc.height = 48;
			npc.aiStyle = 7;
			npc.damage = 20;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Nurse;
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
						if (player.inventory[j].type == mod.ItemType("FarmerShovel"))
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
					return "Trillian";
				case 1:
					return "Penelope";
				case 2:
					return "Emily";
				case 3:
					return "Abigail";
				case 4:
					return "Alma";
				case 5:
					return "Alexandra";
				default:
					return "Peg";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(6))
			{
				case 0:
					return "I wonder who had the idea of growing such an evil corn? Don't look at me like this, I have nothing to do with.";
				case 1:
					return "There are so many wonderful and amazing plants in this world but there is nothing more amazing like a corn!";
				case 2:
					return "Uh... Oh... Did you came to buy a corn? I'm afraid that it can become evil too.";
				case 3:
					return "Don't use chemicals on your plants! Chemicals make them being evil and crazy!";
				case 4:
					return "Don't you dare to offer me to eat popcorn! After those bad events I just can't eat anything that contains corn!";
				default:
					return "Take some water... Add ebonkoi... Wallow some deathweed dust... Mix everything... Oh! Hello! Want to buy something?";
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
			//shop.item[nextSlot].SetDefaults(mod.ItemType("CornSeed"));
			//nextSlot++;
			if (!NPC.downedBoss1)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("Pitchfork"));
				nextSlot++;
			}
			if (Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(307);
				nextSlot++;
			}
			if (!Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(308);
				nextSlot++;
			}
			if (NPC.downedSlimeKing)
			{
				shop.item[nextSlot].SetDefaults(311);
				nextSlot++;
			}
			if (NPC.downedBoss2)
			{
				shop.item[nextSlot].SetDefaults(309);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("EggPlant"));
				nextSlot++;
			}

			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(312);
				nextSlot++;
			}

			if (Main.player[Main.myPlayer].HasItem(mod.ItemType("Carrow")))
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("Carrot"), false);
				nextSlot++;
			}

			if (Main.bloodMoon)
			{
				shop.item[nextSlot].SetDefaults(310);
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
			projType = mod.ProjectileType("TomatoPro");
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