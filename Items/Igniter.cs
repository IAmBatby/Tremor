using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Igniter : ModItem
	{
		public override void SetDefaults()
		{

			item.mana = 9;
			item.UseSound = SoundID.Item105;
			item.useStyle = 5;
			item.damage = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.width = 36;
			item.height = 40;
			item.shoot = mod.ProjectileType("Igniter");
			item.shootSpeed = 13f;
			item.knockBack = 4.4f;
			Item.staff[item.type] = true;
			item.magic = true;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.rare = 5;
			item.noMelee = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Igniter");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddIngredient(null, "FireFragment", 9);
			recipe.AddIngredient(2701, 25);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
