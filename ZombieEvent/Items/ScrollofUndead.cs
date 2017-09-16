using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Invasion;

namespace Tremor.ZombieEvent.Items
{
	public class ScrollofUndead : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 40;
            item.height = 28;
            item.maxStack = 20;
            item.value = 100;
            item.rare = 3;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Scroll of Undead");
      Tooltip.SetDefault("Begins the Night of the Undead");
    }

    public override bool CanUseItem(Player player)
    {
            CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
            if (ZWorld.ZInvasion)
			{
                return false;
			}
			
			if (Main.dayTime)
			{
				return false;
			}
            return true;
    }

        public override bool UseItem(Player player)
        {
            CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
            Main.NewText("Undead creatures are rising from ground!", 175, 75, 255);
            Main.NewText("The Night of Undead has begun...", 135, 17, 17);
            ZWorld.ZInvasion = true;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TornPapyrus", 3);
            recipe.AddIngredient(null, "BottledGlue", 2);
            recipe.AddIngredient(null, "UntreatedFlesh", 5);
            recipe.AddIngredient(ItemID.Amethyst, 4);
            recipe.SetResult(this);
            recipe.AddTile(null, "FleshWorkstationTile");
            recipe.AddRecipe();
        }
    }
}
