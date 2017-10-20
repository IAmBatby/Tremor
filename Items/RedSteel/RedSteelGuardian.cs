using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.RedSteel
{
	[AutoloadEquip(EquipType.Shield)]
	public class RedSteelGuardian : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 32;
			item.value = 250;
			item.rare = 1;
			item.accessory = true;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Steel Guardian");
			Tooltip.SetDefault("10% increased movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.2f;
		}
		/*
		public override bool CanEquipAccessory(Player player, int slot)
				{
					bool canequip = true;
					for (int l = 3; l < 8 + player.extraAccessorySlots; l++)
					{
						if (player.armor[l].type == mod.ItemType("BorealwoodShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("CopperShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("EbonwoodShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("EnchantedShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("GoldShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("IronShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("LeadShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("OrcishShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("PalmwoodShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("PearlwoodShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("PlatinumGuardian"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("RichMahoganyShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("ShadewoodShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("SilverShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("TinShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("TungstenShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("WoodenShield"))
						{
							canequip = false;
							break;
						}
					}
					return canequip;

				}
		*/

		public override void AddRecipes()
		{
			//ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(null, "RedSteelBar", 10);
			//recipe.AddIngredient(null, "FaultyRedSteelShield", 1);
			//recipe.AddTile(16);
			//recipe.SetResult(this);
			//recipe.AddRecipe();
		}
	}
}
