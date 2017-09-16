using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AntlionFury : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 28;
			item.ranged = true;
			item.width = 48;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.shoot = mod.ProjectileType("Sand");
			item.shootSpeed = 17f;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 5;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;

			item.useAmmo = AmmoID.Sand;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antlion Fury");
			Tooltip.SetDefault("Quickly shoots sand blocks\nUses sand blocks as ammo");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}
	}
}
