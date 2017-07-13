using Terraria;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class NovaBreastplate : ModItem
	{

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 24;
			item.rare = 10;
			item.defense = 22;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Breastplate");
			Tooltip.SetDefault("Increases alchemic damage by 25%\nIncreases alchemic critical strike chance by 20\nGrants 40% chance to not consume flasks");
		}


		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemistCrit += 20;
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.25f;
			player.GetModPlayer<MPlayer>(mod).novaChestplate = true;
			Lighting.AddLight((int)((item.position.X + item.width / 2) / 16f), (int)((item.position.Y + item.height / 2) / 16f), 0.0f, 1.27f, 0.64f);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NovaFragment", 20);
			recipe.AddIngredient(3467, 16);
			recipe.AddTile(412);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
