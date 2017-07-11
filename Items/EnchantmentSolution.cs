using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class EnchantmentSolution : ModItem
	{
		public override bool CanEquipAccessory(Player player, int slot)
		{
			for (int i = 0; i < player.armor.Length; i++)
			{
				MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
				if (modPlayer.enchanted)
				{
					return false;
				}
			}
			return true;
		}

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 30;

			item.value = 250000;
			item.rare = 5;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchantment Solution");
			Tooltip.SetDefault("25% chance not to consume flask");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bottle, 5);
			recipe.AddIngredient(ItemID.SoulofLight, 12);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ItemID.ManaCrystal, 1);
			recipe.AddIngredient(ItemID.LifeCrystal, 1);
			recipe.AddIngredient(null, "BasicFlask", 15);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
			player.AddBuff(mod.BuffType("EnchantmentSolution"), 2);
			modPlayer.enchanted = true;
		}
	}
}
