using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class HadesGreaves : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 500;

			item.rare = 250000;
			item.defense = 42;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hades Greaves");
			Tooltip.SetDefault("Increases movement speed\nAllows to dash\nDouble tap a direction\nAllows you to walk on liquids");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "InfernoSoul", 7);
			recipe.AddIngredient(null, "MagmoniumGreaves", 1);
			recipe.AddIngredient(null, "FireFragment", 17);
			recipe.AddIngredient(null, "Phantaplasm", 10);
			recipe.AddIngredient(ItemID.LivingFireBlock, 8);
			recipe.SetResult(this);
			recipe.AddTile(null, "StarvilTile");
			recipe.AddRecipe();
		}

		public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.8f;
			player.dash = 1;
			player.waterWalk = true;
		}
	}
}
