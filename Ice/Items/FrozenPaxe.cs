using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice.Items
{
	public class FrozenPaxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 22;
			item.melee = true;
			item.width = 48;
			item.height = 40;
			item.useTime = 13;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 20000;
			item.rare = 3;
			item.axe = 10;
			item.pick = 60;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frozen Paxe");
			Tooltip.SetDefault("");
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 80);
			}
		}
	}
}
