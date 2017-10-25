using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Afterlife
{
	[AutoloadEquip(EquipType.Head)]
	public class AfterlifeHood : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 10000;
			item.rare = 6;
			item.defense = 7;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Afterlife Hood");
			Tooltip.SetDefault("Increases life regeneration");
		}

		public override void UpdateEquip(Player player)
		{
			player.crimsonRegen = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("AfterlifeBreastplate") && legs.type == mod.ItemType("AfterlifeLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Quickly recovers you if you have low health. But at what cost...";
			if (player.statLife < 25)
			{
				player.lifeRegen += 40;
				player.statDefense = 0;
			}
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowLokis = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SkullTeeth", 2);
			recipe.AddIngredient(null, "SteelBar", 12);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}

	}
}
