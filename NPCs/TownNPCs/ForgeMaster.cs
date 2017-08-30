using System.Linq;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Terraria.Utilities;
using Tremor.Items;
using Tremor.Projectiles;

namespace Tremor.NPCs.TownNPCs
{
	[AutoloadHead]
	public class ForgeMaster : ModNPC
	{
		public override string Texture => "Tremor/NPCs/TownNPCs/ForgeMaster";

		public override string[] AltTextures => new[] { "Tremor/NPCs/TownNPCs/ForgeMaster" };

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
		   => Main.player.Any(player => player.active && player.inventory.Any(item => item != null && item.type == mod.ItemType("JungleAlloy")));

		private readonly WeightedRandom<string> _names = new[]
		{
			"Gefest:2",
			"Aule",
			"Agarorn:2",
			"Treak",
			"Haymer",
			"Golan"
		}.ToWeightedCollectionWithWeight();

		public override string TownNPCName()
			=> _names.Get();

		private readonly WeightedRandom<string> _chats = new[]
		{
			"You can't lift my hammer? Not surprising! That's because you are not worthy!",
			"Strangely but nobody uses hammers for making bars. How do you just put ore into furnaces and get bars!? That is insane!",
			"Valar Morghulis! Oh wait, that's not the Braavos! Forget what I've said.",
			"What? You ask me who am I?! I am the son of the Vulcan and the Vulcan is the mighty anvilborn!",
			"My bars are better because I make them with my hammer. If you won't buy my bars I will make a bar from you.",
			"You wonder why people call me Forge Master!? What means you don't believe I'm the real Master of Forges!?",
			"Be careful when working with forges. I got burnt once when I was taking off a bar from it. That's why I'm wearing such armor!"
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
			shop.AddUniqueItem(ref nextSlot, mod.ItemType("GreatAnvil"));

			if (Main.dayTime)
			{
				shop.AddUniqueItem(ref nextSlot, ItemID.CopperBar);
				shop.AddUniqueItem(ref nextSlot, ItemID.IronBar);
				shop.AddUniqueItem(ref nextSlot, ItemID.SilverBar);

				if (NPC.downedBoss2)
					shop.AddUniqueItem(ref nextSlot, ItemID.GoldBar);
				if (NPC.downedBoss3)
					shop.AddUniqueItem(ref nextSlot, ItemID.DemoniteBar);

				if (NPC.downedMechBossAny)
				{
					shop.AddUniqueItem(ref nextSlot, ItemID.CobaltBar);
					shop.AddUniqueItem(ref nextSlot, ItemID.MythrilBar);
					shop.AddUniqueItem(ref nextSlot, ItemID.AdamantiteBar);
				}
			}
			else
			{
				shop.AddUniqueItem(ref nextSlot, ItemID.TinBar);
				shop.AddUniqueItem(ref nextSlot, ItemID.LeadBar);
				shop.AddUniqueItem(ref nextSlot, ItemID.TungstenBar);

				if (NPC.downedBoss2)
					shop.AddUniqueItem(ref nextSlot, ItemID.PlatinumBar);
				if (NPC.downedBoss3)
					shop.AddUniqueItem(ref nextSlot, ItemID.CrimtaneBar);

				if (NPC.downedMechBossAny)
				{
					shop.AddUniqueItem(ref nextSlot, ItemID.PalladiumBar);
					shop.AddUniqueItem(ref nextSlot, ItemID.OrichalcumBar);
					shop.AddUniqueItem(ref nextSlot, ItemID.TitaniumBar);
				}
			}

			if (NPC.downedBoss2)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<PoisonRod>());
			if (NPC.downedBoss3)
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<BurningHammer>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<PerfectBehemoth>());
			}
			if (NPC.downedPlantBoss)
				shop.AddUniqueItem(ref nextSlot, ItemID.HallowedBar);
			if (NPC.downedGolemBoss)
				shop.AddUniqueItem(ref nextSlot, ItemID.ChlorophyteBar);
			if (NPC.downedAncientCultist)
				shop.AddUniqueItem(ref nextSlot, ItemID.SpectreBar);

			if (Main.hardMode)
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<GoldenMace>());
				shop.AddUniqueItem(ref nextSlot, ItemID.HellstoneBar);
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
			projType = mod.ProjectileType<BurningHammerPro>();
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

				for (int i = 0; i < 4; ++i)
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/BlackSmithGore{i + 1}"), 1f);
			}
		}
	}
}