using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Infector : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 12;
			item.magic = true;
			item.mana = 9;
			item.width = 40;
			item.height = 40;

			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 1500;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = 568;
			item.shootSpeed = 9f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infector");
			Tooltip.SetDefault("Casts spores to infect your enemies!");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RichMahogany, 18);
			recipe.AddIngredient(ItemID.Vine, 1);
			recipe.AddIngredient(ItemID.JungleSpores, 12);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
