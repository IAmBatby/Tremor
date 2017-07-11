using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Utilities;

namespace Tremor
{
	public static class TremorUtils
	{
		public static bool NextBool(this UnifiedRandom rand, int chance, int total)
		{
			return rand.Next(total) < chance;
		}

		public static void DrawNPCGlowMask(SpriteBatch spriteBatch, NPC npc, Texture2D texture)
		{
			var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
							 Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
		}
	}
}
