using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class StarBlaster : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 110;
			item.magic = true;
			item.width = 68;
			item.height = 28;
			item.useTime = 6;
			item.useAnimation = 30;
			item.mana = 5;
			item.shoot = 503;
			item.shootSpeed = 12f;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 300000;
			item.rare = 10;
			item.UseSound = SoundID.Item114;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star Blaster");
			Tooltip.SetDefault("");
		}


		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "StarBar", 20);
			recipe.AddIngredient(null, "Phantaplasm", 6);
			recipe.AddIngredient(null, "CarbonSteel", 6);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 50);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
