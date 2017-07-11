using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class Megalodon : ModItem
{
    public override void SetDefaults()
    {
				item.useStyle = 5;
				item.autoReuse = true;
				item.useAnimation = 4;
				item.useTime = 4;

				item.width = 50;
				item.height = 18;
				item.shoot = 10;
			        item.useAmmo = AmmoID.Bullet;
				item.UseSound = SoundID.Item41;
				item.damage = 73;
				item.shootSpeed = 14f;
				item.noMelee = true;
				item.value = Item.sellPrice(0, 5, 0, 0);
				item.rare = 10;

				item.knockBack = 1.75f;
				item.ranged = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Megalodon");
      Tooltip.SetDefault("50% chance not to consume ammo");
    }



        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-20, 0);
        }      

                public override bool ConsumeAmmo(Player p)
		{
			return Main.rand.Next(3) == 0;
		}

public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
    {
        Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockBack, Main.myPlayer);
        Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
        Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 1, type, damage, knockBack, Main.myPlayer);
    }
    return false;
}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EyeofOblivion", 1);
                                   recipe.AddIngredient(ItemID.Megashark, 1);
			recipe.AddIngredient(null, "NightmareBar", 20);
			recipe.AddIngredient(null, "CarbonSteel", 10);
			recipe.AddIngredient(null, "DeadTissue", 5);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		} 
}}
