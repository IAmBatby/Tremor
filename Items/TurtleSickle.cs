using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TurtleSickle : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 85;
			item.melee = true;
			item.width = 68;
			item.height = 68;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 30000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			//item.shoot = mod.ProjectileType("TurtleSicklePro");
			item.shootSpeed = 6f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Turtle Sickle");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TurtleShell);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 17);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
