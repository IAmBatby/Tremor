using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NebulaBand : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);

			item.rare = 11;
			item.value = 380000;
			item.useTime = 25;
			item.useAnimation = 25;

			item.shoot = mod.ProjectileType("NebulaJellyfish");
			item.buffType = mod.BuffType("NebulaJellyfishBuff");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula Band");
			Tooltip.SetDefault("Summons a nebula jellyfish");
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
			recipe.AddIngredient(3457, 10);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
