using System.Linq;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Tremor.Items;

namespace Tremor.NPCs
{
	[AutoloadHead]
	public class Elf : ModNPC
	{
		public override string Texture => "Tremor/NPCs/Elf";

		public override string[] AltTextures => new[] { "Tremor/NPCs/Elf" };

		public override bool Autoload(ref string name)
		{
			name = "Elf";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elf");
			Main.npcFrameCount[npc.type] = 26;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 6;
			NPCID.Sets.DangerDetectRange[npc.type] = 1000;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 30;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 36;
			npc.height = 44;
			npc.aiStyle = 7;
			npc.damage = 20;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
			=> Main.player.Any(player => player.active && player.inventory.Any(item => item != null && item.type == mod.ItemType("SuspiciousLookingPresent")));

		public override string TownNPCName()
		{
			string[] names =
			{
				"Nick",
				"Elfie",
				"Jingle",
				"Chippy",
				"Sparkle",
				"Twinkle",
				"Elvis",
				"Peppermint",
				"Snowflake"
			};
			return names.TakeRandom();
		}

		public override string GetChat()
		{
			string[] chats =
			{
				"What do you know about reindeers?",
				"I could give you some presents, but... You've been naughty this year.",
				"I am Santa's favorite elf!",
				"Jingle bells, jingle bells, jingle all the way!",
				"Someone threw a snowball at me. I don't know who did it but I will find him and throw a snowball at him too.",
				"I licked an icicle one fine day. It resulted in not a lot of pain."
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
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<CandyCane>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<RedChristmasStocking>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<BlueChristmasStocking>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<GreenChristmasStocking>());

			if (NPC.downedBoss1)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<SnowShotgun>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<CandyBow>());

			if (NPC.downedBoss3)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<TheSnowBall>());

			if (Main.hardMode)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<Blizzard>());
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
			projType = 1;
			attackDelay = 2;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}