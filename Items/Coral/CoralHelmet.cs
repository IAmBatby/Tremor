using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Coral
{
	[AutoloadEquip(EquipType.Head)]
	public class CoralHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 26;

			item.value = 100;
			item.rare = 1;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coral Helmet");
			Tooltip.SetDefault("Allows you to swim");
		}

		public override void UpdateEquip(Player player)
		{
			player.accFlipper = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("CoralChestplate") && legs.type == mod.ItemType("CoralGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Allows you to breath underwater and summons an starfish";
			if (player.breath < player.breathMax - 1)
			{
				player.breath = player.breathMax - 1;
			}
			player.AddBuff(mod.BuffType("StarfishBuff"), 2);
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Coral, 8);
			recipe.AddIngredient(ItemID.Starfish, 6);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}

	}
}
