using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tremor.Items.Sparks
{
	public class WarriorSpark : ModItem
	{
		public override void SetStaticDefaults()
		{
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
			DisplayName.SetDefault("Warrior Spark");
			Tooltip.SetDefault("3% increased melee damage\n" +
			                   "8% increased melee critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.accessory = true;
			item.defense = 2;
			item.rare = 1;
			item.value = Item.buyPrice(silver: 1);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeDamage += 0.03f;
			player.meleeCrit += 8;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AdventurerSpark");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
