using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TrueDeathSickle : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 71;
			item.melee = true;
			item.width = 120;
			item.height = 112;
			item.useTime = 10;
			item.useAnimation = 10;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.useTurn = true;
			item.useStyle = 100;
			item.knockBack = 8f;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = 8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("TrueDeathSickleProj");
			item.shootSpeed = 0f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Death Sickle");
			Tooltip.SetDefault("");
		}

		public override bool UseItemFrame(Player player)
		{
			player.bodyFrame.Y = 3 * player.bodyFrame.Height;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1327);
			recipe.AddIngredient(1570);
			recipe.AddIngredient(548, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
