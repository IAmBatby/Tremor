using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RainStaff : ModItem
	{
		const float RainTimeInMinuts = 15; // Кол-во минут
		const float DistortPercent = 0.1f; // Процент отклонения времени (разброса)

		public override void SetDefaults()
		{

			item.width = 44;
			item.height = 48;

			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 0;
			item.shoot = 1;
			item.value = 12000;
			item.rare = 8;
			item.UseSound = SoundID.Item8;
			item.shoot = 1;
			item.shootSpeed = 0;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rain Staff");
			Tooltip.SetDefault("Allows you to call and revoke precipitation");
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.raining)
				Main.raining = false;

			else
			{
				Main.rainTime = (int)Helper.DistortFloat(RainTimeInMinuts * 60 * 60, DistortPercent);
				Main.raining = true;
				Main.maxRaining *= 2;
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 12);
			recipe.AddIngredient(ItemID.RainCloud, 9);
			recipe.AddIngredient(null, "SeaFragment", 10);
			recipe.SetResult(this);
			recipe.AddTile(null, "MagicWorkbenchTile");
			recipe.AddRecipe();
		}
	}
}
