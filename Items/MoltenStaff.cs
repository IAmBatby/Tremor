using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MoltenStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 26;
			item.magic = true;
			item.mana = 8;
			item.width = 48;
			item.height = 48;

			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 17500;
			item.rare = 2;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = 85;
			item.shootSpeed = 6f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Molten Staff");
			Tooltip.SetDefault("Casts flames to burn your enemies!");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FireFragment", 15);
			recipe.AddIngredient(null, "MoltenParts", 1);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
