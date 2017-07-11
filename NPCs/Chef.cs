using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadHead]
	public class Chef : ModNPC
	{
		public override string Texture => "Tremor/NPCs/Chef";

		public override string[] AltTextures => new[] { "Tremor/NPCs/Chef" };

		public override bool Autoload(ref string name)
		{
			name = "Chef";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chef");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 150;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.AttackType[npc.type] = 3; //this is the attack type,  0 (throwing), 1 (shooting), or 2 (magic). 3 (melee) 
			NPCID.Sets.AttackTime[npc.type] = 30; //this defines the npc attack speed
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
			if (NPC.downedBoss2)
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
					return "Richard";
				case 1:
					return "Oliver";
				case 2:
					return "Alan";
				case 3:
					return "Gordon";
				case 4:
					return "Umeril";
				case 5:
					return "Anthony";
				case 6:
					return "Jerome";
				default:
					return "Liam";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(6))
			{
				case 0:
					return "This crab is so undercooked, it's still singing under the sea!";
				case 1:
					return "This needs more salt! And a dash of powdered blinkroot.";
				case 2:
					return "Any Oaf can make a bowl of soup, while I create culinary art";
				case 3:
					return "Somebody have stolen my knife. I think I will cut this guy with the knife when I will find it.";
				case 4:
					return "No! I will not add vile powder to this flambe.";
				case 5:
					return "Hello there! How's it goin'?";
				default:
					return "Do you know recipes of unusual food? No? THEN GO AND FIND THEM FOR ME OR I WILL CU-... Oh. Sorry.";
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
			shop.item[nextSlot].SetDefaults(mod.ItemType("ButcherAxe"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("Knife"));
			nextSlot++;
			if (NPC.AnyNPCs(mod.NPCType("Farmer")))
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("Carrow"));
				nextSlot++;
			}
			shop.item[nextSlot].SetDefaults(mod.ItemType("ChefHat"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("Durian"));
			nextSlot++;
			if (Main.bloodMoon)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("CursedPopcorn"));
				nextSlot++;
			}
			if (NPC.downedBoss2)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ChickenLegMace"));
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 25;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}


		public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)//Allows you to customize how this town NPC's weapon is drawn when this NPC is swinging it (this NPC must have an attack type of 3). Item is the Texture2D instance of the item to be drawn (use Main.itemTexture[id of item]), itemSize is the width and height of the item's hitbox
		{
			scale = 1f;
			item = Main.itemTexture[mod.ItemType("ButcherAxe")]; //this defines the item that this npc will use
			itemSize = 40;
		}

		public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight) //  Allows you to determine the width and height of the item this town NPC swings when it attacks, which controls the range of this NPC's swung weapon.
		{
			itemWidth = 50;
			itemHeight = 50;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ChefGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ChefGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ChefGore3"), 1f);
			}
		}
	}
}