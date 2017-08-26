using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Items;

namespace Tremor.NPCs
{
	[AutoloadHead]
	public class Undertaker : ModNPC
	{
		public override string Texture => "Tremor/NPCs/Undertaker";

		public override string[] AltTextures => new[] { "Tremor/NPCs/Undertaker" };

		public override bool Autoload(ref string name)
		{
			name = "Undertaker";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Undertaker");
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
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
			=> TremorWorld.Boss.Trinity.IsDowned();

		public override string TownNPCName()
		{
			string[] names =
			{
				"Tenner",
				"Geyer",
				"Cleve",
				"Ferron",
				"Gasper",
				"Spots",
				"Hargon"
			};
			return names.TakeRandom();
		}

		public override string GetChat()
		{
			// weighted chats?
			string[] chats =
			{
				"Don't worry. Nobody will get out of the coffin that I have made.",
				"Are you afraid of ghosts? I'm not. But the ghosts are afraid of me.",
				"If you need some help then feel free to ask me. I have a lot of undead things on my side.",
				"If you need some help then feel free to ask me. I have a lot of undead things on my side.",
				"If you need some help then feel free to ask me. I have a lot of undead things on my side.",
				"What will you prefer to do if this day will be your last day?",
				"Our life is a challenge. To make it easier - buy my stuff.",
				"Don't worry. I'm not a vampire even my eyes are red and my skin is of a strange color.",
				"Do you prefer blood or tomato juice?"
			};
			return chats.TakeRandom();
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
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<Skullheart>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<SpearofJustice>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<TheGhostClaymore>());
			if (!Main.dayTime)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<LivingTombstone>());
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 150;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = 645;
			attackDelay = 5;
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
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/TheUndertakerGore{i+1}"), 1f);
			}
		}
	}
}