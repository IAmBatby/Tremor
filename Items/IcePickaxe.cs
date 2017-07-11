using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class IcePickaxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 32;
			item.melee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 5;
			item.useAnimation = 16;
			item.pick = 200;
			item.axe = 24;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 200000;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Pickaxe");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FrostoneBar", 12);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
