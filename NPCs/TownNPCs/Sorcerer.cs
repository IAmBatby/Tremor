using System.Linq;
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
	public class Sorcerer : ModNPC
	{
		public override string Texture => $"{typeof(Sorcerer).NamespaceToPath()}/Sorcerer";

		public override string[] AltTextures => new[] { $"{typeof(Sorcerer).NamespaceToPath()}/Sorcerer" };

		public override bool Autoload(ref string name)
		{
			name = "Sorcerer";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sorcerer");
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
			npc.width = 32;
			npc.height = 54;
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
			=> Main.player.Any(player => !player.dead);

		private readonly WeightedRandom<string> _names = new[]
		{
			"Merdok:2",
			"Avalon:3",
			"Aron",
			"Harry",
			"Edgar",
			"Marco"
		}.ToWeightedCollectionWithWeight();

		public override string TownNPCName()
			=> _names.Get();

		private readonly WeightedRandom<string> _chats = new[]
		{
			"You'll never find me trapped underground.",
			"Sorcery is all about control. It's different from magic in that it requires symbols and fetishes.",
			"I can share the magic with you for free. Well... Almost free.",
			"Sorry. I don't do parties.",
			"Don't touch that if you want to keep your hand. It's still quite unstable.",
			"I want to get the rabbit out of the hat! Do you want it? You don't want a rabbit? Seriously!?"
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
			shop.AddUniqueItem(ref nextSlot, ItemID.Bunny);
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<BurningTome>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<RazorleavesTome>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<EnchantedShield>());
			if (NPC.downedBoss1)
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<StarfallTome>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<GoldenHat>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<GoldenRobe>());
			}
			if (NPC.downedBoss2)
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<LightningTome>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<Bloomstone>());
			}

			if (Main.hardMode)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<ManaDagger>());
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 22;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = 124;
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

				for (int i = 0; i < 3; ++i)
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/SorcererGore{i + 1}"), 1f);
			}
		}
	}
}