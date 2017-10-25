using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Crystal
{
	public class MushroomCrystal : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 24;
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
			DisplayName.SetDefault("Mushroom Crystal");
			Tooltip.SetDefault("Summons Fungus Beetle\n" +
"Requires EoW or BoC to have been slain");
		}

		public override bool CanUseItem(Player player)
		{
			return NPC.downedBoss3 && !NPC.AnyNPCs(mod.NPCType("FungusBeetle"));
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GlowingMushroom, 15);
			recipe.AddIngredient(null, "Gloomstone", 8);
			recipe.AddIngredient(ItemID.StoneBlock, 10);
			recipe.AddIngredient(ItemID.Sapphire, 12);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("FungusBeetle"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
	}
}
