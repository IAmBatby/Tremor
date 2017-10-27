using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class PalladiumHat : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 24;

			item.value = 400;
			item.rare = 4;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Palladium Hat");
			Tooltip.SetDefault("18% increased minion damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.18f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1208 && legs.type == 1209;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases your max number of minions and greatly increases life regeneration after striking an enemy";
			player.maxMinions += 1;
			player.onHitRegen = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PalladiumBar, 12);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
