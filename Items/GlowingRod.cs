using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GlowingRod : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 20;
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
			item.shoot = mod.ProjectileType("ZootalooRodPro");
			item.shootSpeed = 15f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowing Rod");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AmethystStaff, 1);
			recipe.AddIngredient(null, "LightBulb", 8);
			recipe.AddIngredient(null, "RockHorn", 3);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TopazStaff, 1);
			recipe.AddIngredient(null, "LightBulb", 8);
			recipe.AddIngredient(null, "RockHorn", 3);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SapphireStaff, 1);
			recipe.AddIngredient(null, "LightBulb", 8);
			recipe.AddIngredient(null, "RockHorn", 3);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EmeraldStaff, 1);
			recipe.AddIngredient(null, "LightBulb", 8);
			recipe.AddIngredient(null, "RockHorn", 3);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DiamondStaff, 1);
			recipe.AddIngredient(null, "LightBulb", 8);
			recipe.AddIngredient(null, "RockHorn", 3);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RubyStaff, 1);
			recipe.AddIngredient(null, "LightBulb", 8);
			recipe.AddIngredient(null, "RockHorn", 3);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

		}
	}
}
