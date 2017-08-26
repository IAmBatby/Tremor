using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class WhiteMasterChestplate : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 20;
			item.value = 50000;
			item.rare = 11;
			item.defense = 33;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("White Master Chestplate");
			Tooltip.SetDefault("Massively increases alchemic damage as health lowers\nIncreases alchemic damage by 30%\nEnemy attacks have 10% chance to do no damage to you\nImmune to cursed inferno, lava, and can move through liquids");
		}

		public override void UpdateEquip(Player player)
		{
			TremorPlayer modPlayer = player.GetModPlayer<TremorPlayer>(mod);
			modPlayer.zellariumBody = true;
			player.lavaImmune = true;
			player.ignoreWater = true;
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.3f;
			player.buffImmune[BuffID.CursedInferno] = true;
			if (player.statLife <= player.statLifeMax2)
			{
				player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.3f;
			}
			if (player.statLife <= 400)
			{
				player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.4f;
			}
			if (player.statLife <= 300)
			{
				player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.5f;
			}
			if (player.statLife <= 200)
			{
				player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.6f;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrokenHeroArmorplate", 1);
			recipe.AddIngredient(null, "NovaBreastplate", 1);
			recipe.AddIngredient(null, "Aquamarine", 8);
			recipe.AddIngredient(null, "SoulofFight", 14);
			recipe.AddIngredient(null, "Phantaplasm", 8);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
