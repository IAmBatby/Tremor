using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Items
{
    public class AncientMosaic : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 30;
            item.height = 30;
            item.maxStack = 1;

            item.rare = 4;
            item.maxStack = 20;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ancient Mosaic");
      Tooltip.SetDefault("Summons the Alchemaster");
    }


    public override bool CanUseItem(Player player)
    {
        return !Main.dayTime && Main.hardMode && !NPC.AnyNPCs(mod.NPCType("Alchemaster"));
    }

	
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Alchemaster"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RedPuzzleFragment", 1);
            recipe.AddIngredient(null, "GreenPuzzleFragment", 1);
            recipe.AddIngredient(null, "YellowPuzzleFragment", 1);
            recipe.AddIngredient(null, "PurplePuzzleFragment", 1);
            recipe.AddIngredient(null, "BottledGlue", 1);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }

    }
}
