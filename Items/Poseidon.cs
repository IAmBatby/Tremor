using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Poseidon : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 26;
			item.width = 16;
			item.height = 32;
			item.useTime = 27;
			item.ranged = true;
			item.shoot = 1;
			item.shootSpeed = 15f;
			item.useAnimation = 27;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 12540;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 3;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Poseidon");
			Tooltip.SetDefault("");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}

		//public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		//{		
		//	type = mod.ProjectileType("ElectricBolt");			
		//	return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		//}	


	}
}
