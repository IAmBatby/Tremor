using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Items
{
    public class itemBoneHook : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 32;
            item.melee = true;
            item.width = 42;
            item.height = 38;

            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 2;
            item.knockBack = 0;
            item.value = 20000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("projBoneHook");
            item.shootSpeed = 20;
            item.noMelee = true;
            item.noUseGraphic = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Bone Hook");
      Tooltip.SetDefault("'Fresh meat!'");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PetrifiedSpike", 25);
            recipe.AddIngredient(null, "SharpenedTooth", 6);
            recipe.AddIngredient(ItemID.SoulofNight, 9);
            recipe.AddIngredient(ItemID.SoulofLight, 9);
            recipe.AddIngredient(ItemID.Chain, 10);
            recipe.SetResult(this);
	    recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
