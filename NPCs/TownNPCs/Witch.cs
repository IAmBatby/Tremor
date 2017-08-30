using System.Linq;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Terraria.Utilities;
using Tremor;
using Tremor.Items;
using Tremor.Projectiles;

namespace Tremor.NPCs.TownNPCs
{
	[AutoloadHead]
	public class Witch : ModNPC
	{
		public override string Texture => "Tremor/NPCs/TownNPCs/Witch";

		public override string[] AltTextures => new[] { "Tremor/NPCs/TownNPCs/Witch" };

		public override bool Autoload(ref string name)
		{
			name = "Witch";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Witch");
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
			=> Main.player.Any(player => player.active && player.inventory.Any(item => item != null && item.type == ItemID.GoodieBag));

		private readonly WeightedRandom<string> _names = new[]
		{
			"Circe",
			"Kikimora:2",
			"Morgana",
			"Hecate"
		}.ToWeightedCollectionWithWeight();

		public override string TownNPCName()
			=> _names.Get();

		private readonly WeightedRandom<string> _chats = new[]
		{
			"<cackle> Welcome dearies! I hope you don't mind the body parts. I was just cleaning up.",
			"Eye of a newt! Tongue of a cat! Blood of a dryad... a little more blood.",
			"Don't pull my nose! It's not a mask!",
			"The moon has a secret dearies! One that you'll know soon enough!",
			"This is halloween! Or is it?",
			"Blood for the blood moon! Skulls for the skull cap... Or was it something else?"
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
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<PlagueMask>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<PlagueRobe>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<SacrificalScythe>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<Scarecrow>());

			if (NPC.downedBoss1)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<BoomSpear>());
			if (NPC.downedBoss2)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<BlackRose>());
			if (NPC.downedBoss3)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<Pumpspell>());
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
			projType = mod.ProjectileType<PumpkinPro>();
			attackDelay = 2;
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

				for (int i = 0; i < 3; i++)
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/WitchGore{i + 1}"), 1f);
			}
		}
	}
}