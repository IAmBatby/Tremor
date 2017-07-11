using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class MechanicalBrain : ModItem
	{

		const int XOffset = 0;
		const int YOffset = -200;

		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 18;
			item.maxStack = 20;

			item.rare = 5;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechanical Brain");
			Tooltip.SetDefault("Summons the Motherboard");
		}


		public override bool CanUseItem(Player player)
		{
			return Main.hardMode && !Main.dayTime && !NPC.AnyNPCs(mod.NPCType("Motherboard"));
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Motherboard"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Vertebrae, 6);
			recipe.AddIngredient(ItemID.IronBar, 6);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Vertebrae, 6);
			recipe.AddIngredient(ItemID.LeadBar, 6);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
