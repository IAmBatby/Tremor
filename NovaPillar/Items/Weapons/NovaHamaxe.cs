using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Items.Weapons
{
	public class NovaHamaxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 60;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 9;
			item.useAnimation = 27;
			item.axe = 20;
			item.hammer = 150;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 50000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.tileBoost += 4;
			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Hamaxe");
			Tooltip.SetDefault("");
			TremorGlowMask.AddGlowMask(item.type, "Tremor/NovaPillar/Items/Weapons/NovaHamaxe_Glow");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NovaFragment", 14);
			recipe.AddIngredient(3467, 12);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
