using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SandstonePickaxe : ModItem
	{
		public override void SetDefaults()
		{

			item.autoReuse = true;
			item.useStyle = 1;
			item.useAnimation = 45;
			item.useTime = 21;
			item.pick = 46;
			item.width = 24;
			item.height = 28;
			item.damage = 8;
			item.knockBack = 6f;
			item.scale = 1.3f;
			item.UseSound = SoundID.Item1;
			item.rare = 1;
			item.value = 13500;
			item.melee = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Pickaxe");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AntlionShell", 1);
			recipe.AddIngredient(ItemID.Topaz, 4);
			recipe.AddIngredient(ItemID.AntlionMandible, 4);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
