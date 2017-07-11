using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ShroomiteMagicalBoots : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 20;
			item.value = 11000;
			item.rare = 9;


			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomite Magical Boots");
			Tooltip.SetDefault("The less mana, the more defense...\nThe less health, the more speed...");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			if (player.statMana < 25)
			{
				player.statDefense += 10;
			}
			if (player.statMana < 100)
			{
				player.statDefense += 8;
			}
			if (player.statMana < 200)
			{
				player.statDefense += 6;
			}
			if (player.statMana < 300)
			{
				player.statDefense += 3;
			}
			if (player.statLife < 50)
			{
				player.moveSpeed += 1f;
			}
			if (player.statLife < 100)
			{
				player.moveSpeed += 0.9f;
			}
			if (player.statLife < 200)
			{
				player.moveSpeed += 0.7f;
			}
			if (player.statLife < 300)
			{
				player.moveSpeed += 0.5f;
			}
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ShroomiteMechanicalBoots", 1);
			recipe.AddIngredient(null, "SpectreNecklace", 1);
			recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.AddRecipe();
		}
	}
}
