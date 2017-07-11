using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class NightingaleHood : ModItem
	{

		public override void SetDefaults()
		{


			item.defense = 5;
			item.width = 26;
			item.height = 32;
			item.value = 2000;
			item.rare = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightingale Hood");
			Tooltip.SetDefault("Increases life regeneration");
		}


		public override void UpdateEquip(Player player)
		{
			player.lifeRegen += 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("NightingaleChestplate") && legs.type == mod.ItemType("NightingaleGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Reduced enemy agression";
			player.AddBuff(106, 300, true);
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowLokis = true;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SteelBar", 5);
			recipe.AddIngredient(ItemID.Silk, 15);
			recipe.AddIngredient(null, "PhantomSoul", 3);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
