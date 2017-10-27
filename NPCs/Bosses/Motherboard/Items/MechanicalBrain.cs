using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs.Bosses.Motherboard.Items
{
	public class MechanicalBrain : ModItem
	{
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
			Tooltip.SetDefault("Summons the Motherboard\n" +
"Requires hardmode and night time");
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
			recipe.anyIronBar = true;
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
