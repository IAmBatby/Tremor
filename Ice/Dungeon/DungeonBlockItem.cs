using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice.Dungeon
{
	public class DungeonBlockItem : ModItem
	{
		public override void SetDefaults()
		{

            item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("DungeonBlock");
            ItemID.Sets.ExtractinatorMode[item.type] = item.type;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Frost Brick");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "IceBlockB", 2);
        recipe.SetResult(this);
        recipe.AddTile(18);
        recipe.AddRecipe();

        recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "DungeonWallItem", 4);
        recipe.SetResult(this);
        recipe.AddTile(18);
        recipe.AddRecipe();
    }
	}
}
