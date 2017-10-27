using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FlowerofAntimony : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 60;
			item.magic = true;
			item.mana = 11;
			item.width = 40;
			item.height = 40;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 13800;
			item.rare = 4;
			item.UseSound = SoundID.Item43;
			item.autoReuse = false;
			Item.staff[item.type] = true;
			item.shoot = mod.ProjectileType("FlowerofAntimony");
			item.shootSpeed = 15f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flower of Antimony");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RuneBar", 12);
			recipe.AddIngredient(null, "Gloomstone", 15);
			recipe.AddIngredient(null, "Jellyxir", 6);
			recipe.SetResult(this);
			recipe.AddTile(null, "AlchematorTile");
			recipe.AddRecipe();
		}
	}
}
