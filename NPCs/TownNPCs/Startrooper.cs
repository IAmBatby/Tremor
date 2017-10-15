using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Tremor.Items;
using Tremor.Projectiles;

namespace Tremor.NPCs.TownNPCs
{
	[AutoloadHead]
	public class Startrooper : ModNPC
	{
		public override string Texture => $"{typeof(Startrooper).NamespaceToPath()}/Startrooper";

		public override string[] AltTextures => new[] { $"{typeof(Startrooper).NamespaceToPath()}/Startrooper" };

		public override bool Autoload(ref string name)
		{
			name = "Startrooper";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Startrooper");
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

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
			=> TremorWorld.Boss.SpaceWhale.IsDowned() && Main.player.Any(player => !player.dead);

		private readonly WeightedRandom<string> _names = new[]
		{
			"Ripley:2",
			"Dallas",
			"Brett",
			"Kane:2",
			"Ash",
			"Parker",
			"Lambert"
		}.ToWeightedCollectionWithWeight();

		public override string TownNPCName()
			=> _names.Get();

		private readonly WeightedRandom<string> _chats = new[]
		{
			"There is an explanation for anything, you know.",
			"If you get into a trouble remember that somebody will surely save your skin.",
			"My friend always liked to tell me the odds but now he is dead. You should know: Never tell me the odds.",
			"That giant flying fish that you've defeated was making plans to destroy my home-planet. Glad you've killed him.",
			"I suggest you carrying at least small blaster - nobody knows what's on mind of this creatures in this world.",
			"Have you ever heard a tale of a giant three eyed creature with eyes in it hands and tentacles on head? I'm very glad that it is just a stupid story.",
			"There were some cult of men calling themselve knights and fighting with some kind of light swords on a planet I was travelling once to. As for me, a gun is better than a useless sword."
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
			// todo: change to data representation with conditionals, loop
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<Starmine>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<ChainBow>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<EnforcerShield>());

			if (!Main.dayTime)
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<SniperHelmet>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<SniperBreastplate>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<SniperBoots>());
			}
			else
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<ParatrooperLens>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<StartrooperFlameburstPistol>());
			}

			if (TremorWorld.Boss.Trinity.IsDowned())
			{
				if (!Main.dayTime)
				{
					shop.AddUniqueItem(ref nextSlot, mod.ItemType<CosmicAssaultRifle>());
				}
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<WartimeRocketLauncher>());
			}

			if (Main.bloodMoon)
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<ParatrooperShotgun>());
			}

			if (Main.LocalPlayer.HasItem(mod.ItemType<SuperBigCannon>()))
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<SBCCannonballAmmo>());
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 310;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 15;
			randExtraCooldown = 15;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = mod.ProjectileType<StarminePro>();
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

				for (int i = 0; i < 3; i++)
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/StartrooperNGore{i+1}"), 1f);
			}
		}
	}
}