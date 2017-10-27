using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NovaBand : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);

			item.rare = 11;
			item.value = 380000;
			item.useTime = 25;
			item.useAnimation = 25;

			item.shoot = mod.ProjectileType("Warkee");
			item.buffType = mod.BuffType("WarkeeBuff");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Band");
			Tooltip.SetDefault("Summons a warkee");
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "UnchargedBand");
			recipe.AddIngredient(null, "NovaFragment", 10);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
