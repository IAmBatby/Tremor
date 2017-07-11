using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class RupicideStaff : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 18;
        item.magic = true;
        item.mana = 14;
        item.width = 40;
        item.height = 40;
        item.useTime = 16;
        item.useAnimation = 16;
        item.useStyle = 5;
        item.noMelee = true;
        item.knockBack = 3;
        item.value = 13800;
        item.rare = 4;
        item.UseSound = SoundID.Item43;
        item.autoReuse = false;
        Item.staff[item.type] = true;
        item.shoot = 682;
        item.shootSpeed = 15f;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Rupicide Staff");
      Tooltip.SetDefault("");
    }



public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
        int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
        Main.projectile[proj].hostile = false;
        Main.projectile[proj].friendly = true;
        return false;
}
    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "Gloomstone", 5);
        recipe.AddIngredient(null, "RupicideBar", 5);
        recipe.AddIngredient(null, "WickedHeart", 1);
        recipe.AddTile(null, "NecromaniacWorkbenchTile");
        recipe.SetResult(this);
        recipe.AddRecipe();
    }

}}
