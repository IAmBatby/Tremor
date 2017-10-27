using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Banshee : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Banshee");
			Main.npcFrameCount[npc.type] = 9;
		}

		public override void SetDefaults()
		{
			npc.width = 50;
			npc.height = 62;
			npc.damage = 21;
			npc.defense = 10;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 5, 7);
			npc.knockBackResist = 0.3f;
			npc.aiStyle = 3;
			aiType = 529;
			animationType = 529;
			npc.buffImmune[20] = true;
			npc.buffImmune[31] = false;
			npc.buffImmune[24] = true;
			banner = npc.type;
			bannerItem = mod.ItemType("BansheeBanner");
			NPCID.Sets.TrailCacheLength[npc.type] = 5;
		}

		public override void AI()
		{

			if (Main.rand.Next(500) == 0)
				Main.PlaySound(101, (int)npc.position.X, (int)npc.position.Y, 1);
			if (Main.rand.Next(500) == 0)
				Main.PlaySound(100, (int)npc.position.X, (int)npc.position.Y, 1);
			if (Main.rand.Next(500) == 0)
				Main.PlaySound(102, (int)npc.position.X, (int)npc.position.Y, 1);

			for (int i = npc.oldPos.Length - 1; i > 0; i--)
			{
				npc.oldPos[i] = npc.oldPos[i - 1];
			}
			npc.oldPos[0] = npc.position;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.npcTexture[npc.type].Width, Main.npcTexture[npc.type].Height * 0.8f);
			for (int k = 0; k < npc.oldPos.Length; k++)
			{
				SpriteEffects effect = npc.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
				Color color = npc.GetAlpha(lightColor) * ((npc.oldPos.Length - k) / (float)npc.oldPos.Length);
				Rectangle frame = new Rectangle(0, 164 * (k / 60), 50, 62);

				spriteBatch.Draw(Main.npcTexture[npc.type], npc.oldPos[k] - Main.screenPosition, frame, color, 0, Vector2.Zero, npc.scale, effect, 1f);
			}
			return true;
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(2))
			{
				npc.NewItem((short)ItemID.Sapphire, 2);
				npc.NewItem((short)ItemID.Ruby, 2);
				npc.NewItem((short)ItemID.Emerald, 2);
			}
			if (Main.rand.NextBool(2))
			{
				npc.NewItem((short)ItemID.Topaz, 2);
				npc.NewItem((short)ItemID.Amethyst, 2);
				npc.NewItem((short)ItemID.Diamond, 2);
			}
			if (Main.rand.Next(32) == 0)
				npc.NewItem((short)mod.ItemType<ThunderRay>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BansheeGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BansheeGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BansheeGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BansheeGore3"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.spawnTileY > Main.rockLayer ? 0.004f : 0f;
		}
	}
}
