using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class RupicideCannon : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 45;
        item.width = 40;
        item.height = 20;
        item.useTime = 15;
        item.useAnimation = 15;
        item.useStyle = 5;
        item.magic = true;
        item.mana = 7;
        item.noMelee = true;

        item.knockBack = 6;
        item.value = 10000;
        item.rare = 5;
        item.UseSound = SoundID.Item11;
        item.autoReuse = true;
        item.shoot = 10; 
        item.shootSpeed = 12f;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Rupicide Cannon");
      Tooltip.SetDefault("Shoots magical blasts");
    }

public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
        int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 675, damage, knockBack, Main.myPlayer);
        Main.projectile[proj].hostile = false;
        Main.projectile[proj].friendly = true;
        return false;
}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "GunBlueprint", 1);
        recipe.AddIngredient(null, "RupicideBar", 8);
        recipe.AddIngredient(null, "RuneBar", 8);
        recipe.AddIngredient(null, "CryptStone", 3);
        recipe.AddTile(null, "NecromaniacWorkbenchTile");
        recipe.SetResult(this);
        recipe.AddRecipe();
    }

    public override Vector2? HoldoutOffset()
        {
            return new Vector2(-18, -4);
        }

}}
