using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class WhiteMasterGreaves : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 50000;
			item.rare = 11;
			item.defense = 24;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("White Master Greaves");
			Tooltip.SetDefault("Massively increases alchemic critical chance as health lowers\nIncreases alchemic critical chance by 10\nIncreases life regeneration while moving\nIncreases movement speed by 35%");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.35f;
			if (player.velocity.X != 0)
			{
				player.lifeRegen += 6;
			}
			else if (player.velocity.Y != 0)
			{
				player.lifeRegen += 6;
			}
			player.GetModPlayer<MPlayer>(mod).alchemistCrit += 10;
			if (player.statLife <= player.statLifeMax2)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 10;
			}
			if (player.statLife <= 400)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 15;
			}
			if (player.statLife <= 300)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 20;
			}
			if (player.statLife <= 200)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 25;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrokenHeroArmorplate", 1);
			recipe.AddIngredient(null, "NovaLeggings", 1);
			recipe.AddIngredient(null, "Aquamarine", 6);
			recipe.AddIngredient(null, "SoulofFight", 8);
			recipe.AddIngredient(null, "Phantaplasm", 4);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
