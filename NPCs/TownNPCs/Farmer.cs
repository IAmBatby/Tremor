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
	public class Farmer : ModNPC
	{
		public override string Texture => $"{typeof(Farmer).NamespaceToPath()}/Farmer";

		public override string[] AltTextures => new[] { $"{typeof(Farmer).NamespaceToPath()}/Farmer" };

		public override bool Autoload(ref string name)
		{
			name = "Farmer";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Farmer");
			Main.npcFrameCount[npc.type] = 23;
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
			npc.height = 48;
			npc.aiStyle = 7;
			npc.damage = 20;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Nurse;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
			=> Main.player.Any(player => player.active && player.inventory.Any(item => item != null && item.type == mod.ItemType("FarmerShovel")));

		private readonly WeightedRandom<string> _names = new[]
		{
			"Trillian:2",
			"Penelope:2",
			"Emily",
			"Abigail",
			"Alma",
			"Alexandra",
			"Peg"
		}.ToWeightedCollectionWithWeight();

		public override string TownNPCName()
			=> _names.Get();

		private readonly WeightedRandom<string> _chats = new[]
		{
			"I wonder who had the idea of growing such an evil corn? Don't look at me like this, I have nothing to do with.",
			"There are so many wonderful and amazing plants in this world but there is nothing more amazing like a corn!",
			"Uh... Oh... Did you came to buy a corn? I'm afraid that it can become evil too.",
			"Don't use chemicals on your plants! Chemicals make them being evil and crazy!",
			"Don't you dare to offer me to eat popcorn! After those bad events I just can't eat anything that contains corn!",
			"Take some water... Add ebonkoi... Wallow some deathweed dust... Mix everything... Oh! Hello! Want to buy something?"
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
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<CornSeed>());

			if (!NPC.downedBoss1)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<Pitchfork>());

			if (Main.dayTime)
				shop.AddUniqueItem(ref nextSlot, ItemID.DaybloomSeeds);
			else
				shop.AddUniqueItem(ref nextSlot, ItemID.MoonglowSeeds);

			if (NPC.downedSlimeKing)
				shop.AddUniqueItem(ref nextSlot, ItemID.WaterleafSeeds);
			if (NPC.downedBoss2)
			{
				shop.AddUniqueItem(ref nextSlot, ItemID.BlinkrootSeeds);
				// Eggplant doesn't exist in Tremor namespace.
				//shop.AddUniqueItem(ref nextSlot, mod.ItemType<EggPlant>());
			}

			if (Main.hardMode)
				shop.AddUniqueItem(ref nextSlot, ItemID.FireblossomSeeds);

			if (Main.LocalPlayer.HasItem(mod.ItemType<Carrow>()))
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<Items.Carrot>());

			if (Main.bloodMoon)
				shop.AddUniqueItem(ref nextSlot, ItemID.DeathweedSeeds);
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
			projType = mod.ProjectileType<TomatoPro>();
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