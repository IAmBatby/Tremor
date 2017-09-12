using System;
using System.Linq;
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
			Tooltip.SetDefault("Massively increases alchemical critical chance as health lowers\n10% increased alchemical critical strike chance\nIncreases life regeneration while moving\n35% increased movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.35f;
			player.maxRunSpeed += 0.35f;
			if (Math.Abs(player.velocity.Length()) > 0f)
			{
				player.lifeRegen += 6;
			}
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 10;
			var critIncreases = new[]
			{
				new[]{player.statLifeMax2, 10},
				new[]{400, 15},
				new[]{300, 20},
				new[]{200, 25},
			};
			foreach (int[] increase in critIncreases)
			{
				if (player.statLife <= increase[0])
					player.GetModPlayer<MPlayer>(mod).alchemicalCrit += increase[1];
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
