using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;
using Tremor.Invasion;

namespace Tremor
{
	public class InvasionSky : CustomSky
	{
		private bool isActive = false;
		private float intensity = 0f;
		private int invasionI;

		public override void Update(GameTime gameTime)
		{
			if (isActive && intensity < 1f)
			{
				intensity += 0.01f;
			}
			else if (!isActive && intensity > 0f)
			{
				intensity -= 0.01f;
			}
		}

		private bool UpdatePuritySpiritIndex()
		{
			Mod mod = ModLoader.GetMod("Tremor");
			CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
			if (InvasionWorld.CyberWrath)
			{
				return true;
			}
			invasionI = -1;
			return invasionI >= 0;
		}

		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (maxDepth >= 0 && minDepth < 0)
			{
				spriteBatch.Draw(Main.blackTileTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), new Color(200, 200, 200) * intensity);
			}
		}

		public override float GetCloudAlpha()
		{
			return 0f;
		}

		public override void Activate(Vector2 position, params object[] args)
		{
			isActive = true;
		}

		public override void Deactivate(params object[] args)
		{
			isActive = false;
		}

		public override void Reset()
		{
			isActive = false;
		}

		public override bool IsActive()
		{
			return isActive || intensity > 0f;
		}
	}
}