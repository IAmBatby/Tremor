using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ParaxydeStormbow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 68;
			item.noMelee = true;
			item.ranged = true;
			item.width = 16;
			item.height = 32;
			item.useTime = 15;
			item.shoot = 1;
			item.shootSpeed = 11f;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.knockBack = 1;
			item.useAmmo = AmmoID.Arrow;
			item.value = 216000;
			item.rare = 5;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paraxyde Stormbow");
			Tooltip.SetDefault("Has 33% chance to shoot paraxyde crystal");
		}


		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, -2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ParaxydeShard", 13);
			recipe.SetResult(this);
			recipe.AddTile(null, "AlchematorTile");
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//type = 1;

			if (Main.rand.Next(3) == 0)
			{
				type = 522;
			}

			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}
