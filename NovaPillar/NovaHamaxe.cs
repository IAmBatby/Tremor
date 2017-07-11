using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar
{
	public class NovaHamaxe : ModItem
	{
		private static short glowMaskIndex;

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
			item.glowMask = glowMaskIndex;
			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Hamaxe");
			Tooltip.SetDefault("");
			glowMaskIndex=TremorGlowMask.AddGlowMask("Tremor/NovaPillar/NovaHamaxe_Glow");
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
