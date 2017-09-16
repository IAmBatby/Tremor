using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MoltenHeart : ModItem
	{
		const int XOffset = 300;
		const int YOffset = 100;

		public override void SetDefaults()
		{

			item.width = 40;
			item.height = 28;
			item.maxStack = 20;
			item.value = 100;
			item.rare = 3;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 4;
			item.consumable = true;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Molten Heart");
			Tooltip.SetDefault("Summons Heater of Worlds");
		}

		public override bool CanUseItem(Player player)
		{
			return player.position.Y / 16f > Main.maxTilesY - 200 && NPC.downedBoss2 && !NPC.AnyNPCs(mod.NPCType("HeaterOfWorldsHead"));
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Hellstone, 25);
			recipe.AddIngredient(ItemID.LifeCrystal, 1);
			recipe.AddIngredient(null, "FireFragment", 12);
			recipe.SetResult(this);
			recipe.AddTile(26);
			recipe.AddRecipe();
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("HeaterOfWorldsHead"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
	}
}
