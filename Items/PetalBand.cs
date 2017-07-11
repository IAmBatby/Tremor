using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PetalBand : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 20;
			item.maxStack = 20;

			item.value = 10000;
			item.rare = 5;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Petal Band");
			Tooltip.SetDefault("Summons the Plantera");
		}


		public override bool CanUseItem(Player player)
		{
			return Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !NPC.AnyNPCs(NPCID.Plantera);
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Plantera);
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EssenseofJungle", 1);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
			recipe.AddIngredient(ItemID.Vine, 5);
			recipe.AddIngredient(ItemID.Stinger, 5);
			recipe.SetResult(this);
			recipe.AddTile(26);
			recipe.AddRecipe();
		}
	}
}
