using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadHead]
	public class Archer : ModNPC
	{
		public override string Texture => "Tremor/NPCs/Archer";

		public override string[] AltTextures => new[] { "Tremor/NPCs/Archer" };

		public override bool Autoload(ref string name)
		{
			name = "Arcer";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Archer");
			Main.npcFrameCount[npc.type] = 26;
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

			npc.width = 30;
			npc.height = 48;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.knockBackResist = 0.5f;

			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
			=> Main.player.Any(player => player.active);


		public override string TownNPCName()
		{
			string[] names =
			{
				"Richard",
				"Arthur",
				"Jack",
				"William",
				"Robin",
				"Wales"
			};
			return names[Main.rand.Next(names.Length)];
		}

		public override string GetChat()
		{
			string[] chats =
			{
				"You'd have to be a very good archer in order to shoot an arrow into a knee.",
				"I'd like to get my hands on a goblintech bow. Those things can shoot multiple arrows.",
				"I deal in long distance death! Have a look at my wares.",
				"I will shoot you with my best arrow if you will not buy anything!",
				"Guns? Guns are for cowards!",
				"You don't need to make arrows. You need to buy them!"
			};
			return chats[Main.rand.Next(chats.Length)];
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
			shop.item[nextSlot].SetDefaults(40);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("ArcherGlove"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("Crossbow"));
			nextSlot++;
			if (NPC.downedBoss1)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("Quiver"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("MiniGun"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(51);
				nextSlot++;
			}
			if (NPC.downedBoss2)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("DragonGem"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(47);
				nextSlot++;
			}

			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(516);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(265);
				nextSlot++;
			}

			if (Main.bloodMoon)
			{
				shop.item[nextSlot].SetDefaults(3003);
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

		public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
		{
			scale = 1f;
			item = !Main.hardMode
				? 44 : 3052;
			closeness = 20;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)//Allows you to determine the projectile type of this town NPC's attack, and how long it takes for the projectile to actually appear
		{
			projType = !Main.hardMode
				? ProjectileID.FireArrow : ProjectileID.ShadowFlameArrow;
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
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArcherGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArcherGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArcherGore3"), 1f);
			}
		}
	}
}