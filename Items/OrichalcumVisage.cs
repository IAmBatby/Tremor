using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class OrichalcumVisage : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 26;

			item.value = 400;
			item.rare = 4;
			item.defense = 7;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orichalcum Visage");
			Tooltip.SetDefault("20% increased alchemical damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.20f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1213 && legs.type == 1214;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Flower petals will fall on your target for extra damage\n" +
"16% increased alchemical critical strike chance";
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 16;
			player.onHitPetal = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OrichalcumBar, 12);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
