using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Terraria.Utilities;
using Tremor.Items;

namespace Tremor.NPCs.TownNPCs
{
	[AutoloadHead]
	public class Knight : ModNPC
	{
		public override string Texture => "Tremor/NPCs/TownNPCs/Knight";

		public override string[] AltTextures => new[] { "Tremor/NPCs/TownNPCs/Knight" };

		public override bool Autoload(ref string name)
		{
			name = "Knight";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Knight");
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

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) => true;

		private readonly WeightedRandom<string> _names = new[]
		{
			"Wheatly",
			"Daniel:3",
			"Crox",
			"Geralt:2",
			"Roland",
			"Hodor:4"
		}.ToWeightedCollectionWithWeight();

		public override string TownNPCName()
			=> _names.Get();

		private readonly WeightedRandom<string> _chats = new[]
		{
			"Well met, brave adventurer.",
			"A balanced weapon can mean the difference between victory and defeat.",
			"I am not overly fond of the bovine hordes. Best to leave them alone, really.",
			"Do you have a weapon? Needs about 20% more coolness!",
			"Hail and good morrow my Liege!",
			"I was in a strange castle one day. There were mechanical things saying EXTERMINATE. Were they your minions?",
			"Have you ever met a knight whose name is Sir Uncle Slime? He is a good friend of mine."
		}.ToWeightedCollection();

		public override string GetChat()
			=> Name == "Hodor" ? Name : _chats.Get();

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
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<ThrowingAxe>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<RustySword>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<RipperKnife>());

			if (NPC.downedBoss1)
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<TombRaider>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<SpikeShield>());
			}
			if (NPC.downedBoss2)
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<TwilightHorns>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<ToxicRazorknife>());
			}
			if (NPC.downedBoss3)
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<NecromancerClaymore>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<Shovel>());
			}

			if (Main.hardMode)
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<GoldenThrowingAxe>());

				if(Main.bloodMoon)
					shop.AddUniqueItem(ref nextSlot, mod.ItemType<Oppressor>());
			}
			if (NPC.downedMechBossAny)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<PrizmaticSword>());
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

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = mod.ProjectileType<Projectiles.ThrowingAxe>();
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
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/KnightGore{i+1}"), 1f);
			}
		}
	}
}