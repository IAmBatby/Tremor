using Terraria;
using Terraria.ModLoader;

namespace Tremor.Ice.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class GlacierWoodHelmet : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 26;
			item.value = 400;
			item.rare = 1;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacier Wood Helmet");
			Tooltip.SetDefault("");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GlacierWoodChestplate") && legs.type == mod.ItemType("GlacierWoodLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "1 defense";
			player.statDefense += 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GlacierWood", 20);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}
