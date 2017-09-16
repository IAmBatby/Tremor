using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class MeteorMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 28;

			item.value = 9000;
			item.rare = 1;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteor Mask");
			Tooltip.SetDefault("Increases magic critical strike chance by 9");
		}

		public override void UpdateEquip(Player player)
		{
			player.magicCrit += 9;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 124 && legs.type == 125;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Reduces the mana cost of the Space Gun to zero";
			player.spaceGun = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(117, 15);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
