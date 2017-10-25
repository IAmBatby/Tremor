using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Afterlife
{
	[AutoloadEquip(EquipType.Body)]
	public class AfterlifeBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 10000;

			item.rare = 6;
			item.defense = 11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Afterlife Breastplate");
			Tooltip.SetDefault("9% increased damage\n" +
"Increases your max number of minions");
		}

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 2;
			player.minionDamage += 0.09f;
			player.thrownDamage += 0.09f;
			player.magicDamage += 0.09f;
			player.meleeDamage += 0.09f;
			player.rangedDamage += 0.09f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SkullTeeth", 3);
			recipe.AddIngredient(null, "SteelBar", 20);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
