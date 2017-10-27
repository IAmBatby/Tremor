using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class EndlessPileofsnowballs : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = 1;

			item.shootSpeed = 7f;
			item.shoot = 166;
			item.damage = 8;
			item.width = 18;
			item.height = 20;
			item.maxStack = 1;
			item.ammo = 949;
			item.rare = 2;
			item.consumable = false;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 19;
			item.useTime = 19;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.thrown = true;
			item.knockBack = 5.75f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Pile of snowballs");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Snowball, 3996);
			recipe.SetResult(this);
			recipe.AddTile(125);
			recipe.AddRecipe();
		}

	}
}
