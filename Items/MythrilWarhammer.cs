using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MythrilWarhammer : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 44;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 37;
			item.useAnimation = 37;
			item.hammer = 83;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 27000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mythril Warhammer");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MythrilBar, 10);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
