using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Terraria.Utilities;
using Tremor;
using Tremor.Items;

namespace Tremor.NPCs.TownNPCs
{
	[AutoloadHead]
	public class LadyMoon : ModNPC
	{
		public override string Texture => $"{typeof(LadyMoon).NamespaceToPath()}/LadyMoon";

		public override string[] AltTextures => new[] { $"{typeof(LadyMoon).NamespaceToPath()}/LadyMoon" };

		public override bool Autoload(ref string name)
		{
			name = "Lady Moon";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lady Moon");
			Main.npcFrameCount[npc.type] = 21;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 2;
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
			animationType = NPCID.Dryad;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
			=> NPC.downedMoonlord;

		private readonly WeightedRandom<string> _names = new[]
		{
			"Atria",
			"Mintaka",
			"Nashira:2",
			"Rana",
			"Talita",
			"Zosma",
			"Pleyona:2"
		}.ToWeightedCollectionWithWeight();

		public override string TownNPCName()
			=> _names.Get();

		private readonly WeightedRandom<string> _chats = new[]
		{
			"There are so many beautiful things in this world! What can be more beautiful than a big shining star? Maybe only an exploding big shining star!",
			"I hope this world doesn't have crazy kings that want to kill you. You're not one of them, are you!?",
			"I have heard about an space station called Death Star that can destroy any planet or star! Can you show me this station?",
			"I believe I can fly! I believe I can touch the sk-... Sorry, I forgot that I'm not alone here!",
			"What do you call a man who watches an exploding star? A STARk man!",
			"I was in a strange castle one day. There were mechanical things saying EXTERMINATE. Were they your minions?",
			"Planets are burning, stars are exploding, but the prices for my spacy things are not changing!"
		}.ToWeightedCollection();

		public override string GetChat()
			=> _chats.Get();

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
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<DimensionalTopHat>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<ExtraterrestrialRubies>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<UnchargedBand>());
			if (!Main.dayTime)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<ManaBooster>());
			if (Main.dayTime)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<HealthBooster>());
			if (Main.bloodMoon)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<ChainedRocket>());
			if (Main.eclipse)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<Infusion>());
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 165;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = 12;
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
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for(int i = 0; i < 3; ++i)
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/FarmerGore{i+1}"), 1f);
			}
		}
	}
}