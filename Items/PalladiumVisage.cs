using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class PalladiumVisage : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 20;

			item.value = 400;
			item.rare = 4;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Palladium Visage");
			Tooltip.SetDefault("Increases alchemic damage by 18%");
		}


		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.18f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1208 && legs.type == 1209;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases alchemic critical strike chance by 12% and greatly increases life regeneration after striking an enemy";
			player.GetModPlayer<MPlayer>(mod).alchemistCrit += 12;
			player.onHitRegen = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PalladiumBar, 10);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
