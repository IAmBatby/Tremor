using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Utilities;
using Tremor;
using Tremor.Items;
using Tremor.Items.Cursed;
using Tremor.NPCs.TownNPCs;

namespace Tremor.NPCs.TownNPCs
{
	[AutoloadHead]
	public class Chef : ModNPC
	{
		public override string Texture => $"{typeof(Chef).NamespaceToPath()}/Chef";

		public override string[] AltTextures => new[] { $"{typeof(Chef).NamespaceToPath()}/Chef" };

		public override bool Autoload(ref string name)
		{
			name = "Chef";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chef");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 150;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.AttackType[npc.type] = 3; //this is the attack type,  0 (throwing), 1 (shooting), or 2 (magic). 3 (melee) 
			NPCID.Sets.AttackTime[npc.type] = 30; //this defines the npc attack speed
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
			=> NPC.downedBoss2 && Main.player.Any(player => !player.dead);

		private readonly WeightedRandom<string> _names = new[]
		{
			"Richard",
			"Oliver:2",
			"Alan",
			"Gordon",
			"Umeril:2",
			"Anthony",
			"Jerome:2",
			"Liam"
		}.ToWeightedCollectionWithWeight();

		public override string TownNPCName()
			=> _names.Get();

		private readonly WeightedRandom<string> _chats = new[]
		{
			"This crab is so undercooked, it's still singing under the sea!",
			"This needs more salt! And a dash of powdered blinkroot.",
			"Any Oaf can make a bowl of soup, while I create culinary art.",
			"Somebody stole my knife. I think I will cut the thief with the knife when I find it.",
			"No! I will not add vile powder to this flambe.",
			"Hello there! How's it goin'?",
			"Do you know recipes of unusual food? No? THEN GO AND FIND THEM FOR ME OR I WILL CU-... Oh. Sorry."
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
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<Knife>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<Durian>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<ChefHat>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<ButcherAxe>());

			if (NPC.AnyNPCs(mod.NPCType<Farmer>()))
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<Carrow>());

			if (Main.bloodMoon)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<CursedPopcorn>());
			if (NPC.downedBoss2)
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<ChickenLegMace>());
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

		public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)//Allows you to customize how this town NPC's weapon is drawn when this NPC is swinging it (this NPC must have an attack type of 3). ItemType is the Texture2D instance of the item to be drawn (use Main.itemTexture[id of item]), itemSize is the width and height of the item's hitbox
		{
			scale = 1f;
			item = Main.itemTexture[mod.ItemType<ButcherAxe>()]; //this defines the item that this npc will use
			itemSize = 40;
		}

		public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight) //  Allows you to determine the width and height of the item this town NPC swings when it attacks, which controls the range of this NPC's swung weapon.
		{
			itemWidth = 50;
			itemHeight = 50;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for(int i = 0; i < 3; ++i)
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/ChefGore{i+1}"), 1f);
			}
		}
	}
}