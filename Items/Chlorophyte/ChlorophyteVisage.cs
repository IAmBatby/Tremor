using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Chlorophyte
{
	[AutoloadEquip(EquipType.Head)]
	public class ChlorophyteVisage : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 22;

			item.value = 60000;
			item.rare = 7;
			item.defense = 13;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chlorophyte Visage");
			Tooltip.SetDefault("29% increased alchemical damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.29f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1004 && legs.type == 1005;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Summons a powerful leaf crystal to shoot at nearby enemies\n" +
"25% increased alchemical critical strike chance";
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 25;
			player.AddBuff(60, 60, true);
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
