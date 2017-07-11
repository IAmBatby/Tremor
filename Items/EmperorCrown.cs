using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class EmperorCrown : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 28;
			item.maxStack = 20;
			item.value = 100;
			item.rare = 11;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 4;
			item.consumable = true;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Emperor Crown");
			Tooltip.SetDefault("Summons the Dark Emperor");
		}


		public override bool CanUseItem(Player player)
		{
			return NPC.downedMoonlord && !NPC.AnyNPCs(mod.NPCType("TheDarkEmperor"));
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SlimeCrown, 1);
			recipe.AddIngredient(null, "Doomstone", 9);
			recipe.AddIngredient(null, "DarkMass", 3);
			recipe.SetResult(this);
			recipe.AddTile(26);
			recipe.AddRecipe();
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("TheDarkEmperor"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
	}
}
