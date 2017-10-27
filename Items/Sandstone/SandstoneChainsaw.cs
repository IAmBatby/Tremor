using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Sandstone
{

	public class SandstoneChainsaw : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 16;
			item.melee = true;
			item.width = 20;
			item.height = 12;
			item.useTime = 15;
			item.useAnimation = 25;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.axe = 15;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 13500;
			item.rare = 1;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SandstoneChainsawPro");
			item.shootSpeed = 40f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Chainsaw");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AntlionShell", 1);
			recipe.AddIngredient(ItemID.Topaz, 3);
			recipe.AddIngredient(ItemID.AntlionMandible, 5);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
