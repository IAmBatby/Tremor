using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class MarbleBreastplate : ModItem
	{
		public override void SetDefaults()
		{


			item.defense = 6;
			item.width = 22;
			item.height = 30;
			item.value = 5000;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Marble Breastplate");
			Tooltip.SetDefault("10% increased throwing damage");
		}

		public override void UpdateEquip(Player p)
		{
			p.thrownDamage += 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MarbleBlock, 80);
			recipe.AddIngredient(null, "StoneofLife", 1);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
