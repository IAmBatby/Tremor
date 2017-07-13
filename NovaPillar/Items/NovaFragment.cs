using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Items
{
	public class NovaFragment : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 48;
			item.height = 48;
			item.value = 2000;
			item.rare = 9;
			item.maxStack = 999;

			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Fragment");
			Tooltip.SetDefault("'The constituents of stars are contained in this fragment'");
		}


		public override void PostUpdate()
		{
			Lighting.AddLight(item.Center, new Vector3(0.8f, 0.7f, 0.3f) * Main.essScale);
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3456, 1);
			recipe.AddIngredient(3457, 1);
			recipe.AddIngredient(3458, 1);
			recipe.AddIngredient(3459, 1);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
