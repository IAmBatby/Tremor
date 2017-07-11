using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class SandStoneHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 26;
			item.value = 400;

			item.rare = 2;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Helmet");
			Tooltip.SetDefault("10% increased movement speed");
		}


		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.1f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("SandStoneBreastplate") && legs.type == mod.ItemType("SandStoneGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "The desert winds call a sandstorm to protect you";
			player.AddBuff(mod.BuffType("SandstormMinionBuff"), 2);
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SandstoneBar", 8);
			recipe.AddIngredient(null, "AntlionShell", 1);
			recipe.AddIngredient(null, "PetrifiedSpike", 4);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
