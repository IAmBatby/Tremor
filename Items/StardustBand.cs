using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class StardustBand : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);

			item.rare = 11;
			item.value = 380000;
			item.useTime = 25;
			item.useAnimation = 25;

			item.shoot = mod.ProjectileType("StardustSquid");
			item.buffType = mod.BuffType("StardustSquidBuff");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stardust Band");
			Tooltip.SetDefault("Summons a stardust squid");
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
			recipe.AddIngredient(3459, 10);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
