using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FrostCrown : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 38;
			item.maxStack = 20;

			item.rare = 6;
			item.value = 25000;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Crown");
			Tooltip.SetDefault("Summons the Frost King");
		}

		public override bool CanUseItem(Player player)
		{
			return NPC.downedMechBossAny && !NPC.AnyNPCs(mod.NPCType("FrostKing")) && player.ZoneSnow;
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("FrostKing"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldCrown, 1);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 18);
			recipe.AddIngredient(ItemID.SoulofLight, 18);
			recipe.AddIngredient(null, "FrostCore", 25);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
