using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;
using Tremor.Projectiles;

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
			=> TremorWorld.Boss.Rukh.IsDowned();

		public override string TownNPCName()
		{
			string[] names =
			{
				"Badruddin",
				"Galib",
				"Salavat",
				"Zafar",
				"Valid",
				"Tunak",
				"Nadim"
			};
			return names.TakeRandom();
		}

		public override string GetChat()
		{
			// weighted chats?
			string[] chats =
			{
				"Salam aleykum! Do you need anything?",
				"I got some sand in my pockets. I think throwing it will hurt your eyes.",
				"My wear was absolutely white long time ago. Maybe I should wash it with this perfect yellow water?",
				"There are stories about what happened in the sands of this desert. But I won't tell you anything.",
				"In case something will happen with me... I bequeath you all my sand.",
				"The sands are telling me that... That... Ugh... That you will buy everything!",
				"The sands are moving... Be careful or you will be sucked into unknown depths!"
			};
			return chats.TakeRandom();
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Lang.inter[28].Value;
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			shop = firstButton;
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<GenieLamp>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<JavaHood>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<JavaRobe>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<SandstoneRing>());

			if (NPC.downedBoss1)
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<FossilSugar>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<DesertCrown>());
			}
			if (NPC.downedBoss2)
			{
				shop.AddUniqueItem(ref nextSlot, ItemID.BoneJavelin);
				shop.AddUniqueItem(ref nextSlot, ItemID.BoneDagger);
			}

			if (Main.hardMode)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<DesertEagle>());
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
			projType = mod.ProjectileType<Sand>();
			attackDelay = 4;
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				npc.SpawnItem((short)mod.ItemType<WhiteTurban>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for (int i = 0; i < 3; i++)
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/ArabianMerchantGore{i+1}"), 1f);
			}
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}