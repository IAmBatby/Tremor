using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class WaterSpear : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 34;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 14;
			item.useAnimation = 14;
			item.shoot = 27;
			item.shootSpeed = 26f;
			item.mana = 6;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 99999;
			item.rare = 5;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Water Spear");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WaterBolt, 1);
			recipe.AddIngredient(ItemID.SpellTome, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.SetResult(this);
			recipe.AddTile(101);
			recipe.AddRecipe();
		}
	}
}
