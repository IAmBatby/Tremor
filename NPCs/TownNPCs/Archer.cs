using System.Linq;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Terraria.Utilities;
using Tremor.Items;

namespace Tremor.NPCs.TownNPCs
{
	[AutoloadHead]
	public class Archer : ModNPC
	{
		public override string Texture => "Tremor/NPCs/TownNPCs/Archer";

		public override string[] AltTextures => new[] { "Tremor/NPCs/TownNPCs/Archer" };

		public override bool Autoload(ref string name)
		{
			name = "Archer";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Archer");
			Main.npcFrameCount[npc.type] = 26;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 1000;
			NPCID.Sets.AttackType[npc.type] = 1;
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
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.knockBackResist = 0.5f;

			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
			=> Main.player.Any(player => player.dead);

		private readonly WeightedRandom<string> _names = new[]
		{
			"Richard",
			"Arthur:2",
			"Jack",
			"William:2",
			"Robin",
			"Wales"
		}.ToWeightedCollectionWithWeight();

		public override string TownNPCName()
			=> _names.Get();

		private readonly WeightedRandom<string> _chats = new WeightedRandom<string>(
			"You'd have to be a very good archer in order to shoot an arrow into a knee.".ToWeightedTuple(2),
			"I'd like to get my hands on a goblintech bow. Those things can shoot multiple arrows.".ToWeightedTuple(.5),
			"I deal in long distance death! Have a look at my wares.".ToWeightedTuple(),
			"I will shoot you with my best arrow if you will not buy anything!".ToWeightedTuple(),
			"Guns? Guns are for cowards!".ToWeightedTuple(),
			"You don't need to make arrows. You need to buy them!".ToWeightedTuple()
		);

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
			shop.AddUniqueItem(ref nextSlot, ItemID.WoodenArrow);
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<ArcherGlove>());
			shop.AddUniqueItem(ref nextSlot, mod.ItemType<Crossbow>());

			if (NPC.downedBoss1)
			{
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<Quiver>());
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<MiniGun>());
				shop.AddUniqueItem(ref nextSlot, ItemID.JestersArrow);
			}
			if (NPC.downedBoss2)
			{
				shop.AddUniqueItem(ref nextSlot, ItemID.UnholyArrow);
				shop.AddUniqueItem(ref nextSlot, mod.ItemType<DragonGem>());
			}

			if (Main.hardMode)
			{
				shop.AddUniqueItem(ref nextSlot, ItemID.HolyArrow);
				shop.AddUniqueItem(ref nextSlot, ItemID.HellfireArrow);
			}
			
			if (Main.bloodMoon)
				shop.AddUniqueItem(ref nextSlot, ItemID.BoneArrow);
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

		public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
		{
			scale = 1f;
			item = !Main.hardMode ? ItemID.DemonBow : ItemID.ShadowFlameBow;
			closeness = 20;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)//Allows you to determine the projectile type of this town NPC's attack, and how long it takes for the projectile to actually appear
		{
			projType = !Main.hardMode ? ProjectileID.FireArrow : ProjectileID.ShadowFlameArrow;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)//Allows you to determine the speed at which this town NPC throws a projectile when it attacks. Multiplier is the speed of the projectile, gravityCorrection is how much extra the projectile gets thrown upwards, and randomOffset allows you to randomize the projectile's velocity in a square centered around the original velocity
		{
			multiplier = 7f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for(int i = 0; i < 3; ++i)
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/ArcherGore{i+1}"), 1f);
			}
		}
	}
}