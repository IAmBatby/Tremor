using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tremor.NPCs
{
	public class BoneFish : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bone Fish");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 40;
			npc.damage = 28;
			npc.defense = 6;
			npc.knockBackResist = 0.3f;
			npc.width = 38;
			npc.height = 26;
			animationType = 241;
			npc.aiStyle = 16;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 0, 3);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("BoneFishBanner");
			NPCID.Sets.TrailCacheLength[npc.type] = 5;
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				npc.SpawnItem(ItemID.Bone);
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.npcTexture[npc.type].Width, Main.npcTexture[npc.type].Height * 0.8f);
			for (int k = 0; k < npc.oldPos.Length; k++)
			{
				SpriteEffects effect = npc.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
				Color color = npc.GetAlpha(lightColor) * ((npc.oldPos.Length - k) / (float)npc.oldPos.Length);
				Rectangle frame = new Rectangle(0, 164 * (k / 60), 38, 26);

				spriteBatch.Draw(Main.npcTexture[npc.type], npc.oldPos[k] - Main.screenPosition, frame, color, 0, Vector2.Zero, npc.scale, effect, 1f);
			}
			return true;
		}

		public override void AI()
		{
			for (int i = npc.oldPos.Length - 1; i > 0; i--)
				npc.oldPos[i] = npc.oldPos[i - 1];
			npc.oldPos[0] = npc.position;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BoneFishGore"), 1f);
		}
	}
}