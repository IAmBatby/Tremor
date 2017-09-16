using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CyberCutter : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 76;
			item.magic = true;
			item.width = 38;
			item.height = 38;
			item.scale = 1.1f;
			item.maxStack = 1;

			item.useTime = 45;
			item.useAnimation = 45;
			item.knockBack = 4f;
			item.UseSound = SoundID.Item23;
			item.noMelee = true;
			item.channel = true;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 5;
			item.value = 10000;
			item.rare = 5;
			item.shoot = mod.ProjectileType("CyberCutterPro");
			item.shootSpeed = 5f;
			item.mana = 14;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cyber Cutter");
			Tooltip.SetDefault("Casts a controllable saw");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.channel = true;
			return true;
		}
	}
}
