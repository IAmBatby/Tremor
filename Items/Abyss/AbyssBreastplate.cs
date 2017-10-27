using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Abyss
{
	[AutoloadEquip(EquipType.Body)]
	public class AbyssBreastplate : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 18000;
			item.rare = 7;
			item.defense = 22;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abyss Breastplate");
			Tooltip.SetDefault("14% increased minion damage\n" +
"Increases your max number of minions");
		}

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 2;
			player.minionDamage += 0.14f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarknessCloth", 13);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.Amethyst, 8);
			recipe.AddIngredient(null, "PhantomSoul", 5);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}

	}
}
