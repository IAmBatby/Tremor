using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Adamantite
{
	public class AdamantiteWarhammer : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 49;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 35;
			item.useAnimation = 35;
			item.hammer = 86;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = 27600;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Adamantite Warhammer");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 12);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
