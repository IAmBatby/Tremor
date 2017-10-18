using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Narsil : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 64;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 22;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 125000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Narsil");
			Tooltip.SetDefault("");
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(2))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 57);
			}
		}
	}
}
