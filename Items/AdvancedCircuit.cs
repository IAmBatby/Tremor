using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AdvancedCircuit : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 38;
			item.maxStack = 20;

			item.rare = 7;
			item.value = 30000;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Advanced Circuit");
			Tooltip.SetDefault("Summons the Mothership\n" +
"Requires Plantera to have been slain and night time");
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(mod.NPCType("Mothership")) && NPC.downedPlantBoss && !Main.dayTime;
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Mothership"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GolemCore", 1);
			recipe.AddIngredient(ItemID.HallowedBar, 25);
			recipe.AddIngredient(ItemID.SoulofSight, 12);
			recipe.AddIngredient(ItemID.SoulofMight, 12);
			recipe.AddIngredient(ItemID.SoulofFright, 12);
			recipe.AddIngredient(ItemID.Wire, 30);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GolemCore", 1);
			recipe.AddIngredient(ItemID.HallowedBar, 25);
			recipe.AddIngredient(ItemID.SoulofSight, 12);
			recipe.AddIngredient(null, "SoulofMind", 12);
			recipe.AddIngredient(ItemID.SoulofFright, 12);
			recipe.AddIngredient(ItemID.Wire, 30);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
