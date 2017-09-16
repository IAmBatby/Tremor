using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class BookofRevelations : ModItem
    {
        public override void SetDefaults()
        {
            item.magic = true;
            item.width = 50;
            item.height = 55;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.knockBack = 3;
            item.value = 2000;
            item.rare = 2;
            item.UseSound = SoundID.Item4;
            item.autoReuse = false;
            item.noMelee = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Book of Revelations");
            Tooltip.SetDefault("Drops 4 hearts and 4 mana stars\nHas 20 seconds cooldown");
        }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "Rupicide", 2);
        recipe.AddIngredient(null, "TornPapyrus", 5);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }

        public override bool UseItem(Player player)
        {
            if (player.FindBuffIndex(mod.BuffType("TomeRechargeBuff1")) < 1)
            {
                player.AddBuff(mod.BuffType("TomeRechargeBuff1"), 1200, true);
                Item.NewItem((int)player.position.X - 25, (int)player.position.Y, player.width, player.height, 58, 1);
                Item.NewItem((int)player.position.X - 50, (int)player.position.Y, player.width, player.height, 58, 1);
                Item.NewItem((int)player.position.X - 75, (int)player.position.Y, player.width, player.height, 58, 1);
                Item.NewItem((int)player.position.X - 100, (int)player.position.Y, player.width, player.height, 58, 1);
                Item.NewItem((int)player.position.X + 25, (int)player.position.Y, player.width, player.height, 184, 1);
                Item.NewItem((int)player.position.X + 50, (int)player.position.Y, player.width, player.height, 184, 1);
                Item.NewItem((int)player.position.X + 75, (int)player.position.Y, player.width, player.height, 184, 1);
                Item.NewItem((int)player.position.X + 100, (int)player.position.Y, player.width, player.height, 184, 1);
            }
            return false;
        }

    }
}
