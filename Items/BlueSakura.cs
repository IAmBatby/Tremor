using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BlueSakura : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 7;
			item.summon = true;
			item.mana = 12;
			item.width = 30;
			item.height = 28;

			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 0, 1, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("BlueSakuraPro");
			item.shootSpeed = 1f;
			item.buffType = mod.BuffType("BlueSakuraBuff");
			item.buffTime = 3600;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Blue Sakura");
      Tooltip.SetDefault("Summons a blue wind to fight for you.");
    }


		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			return player.altFunctionUse != 2;
		}
		
		public override bool UseItem(Player player)
		{
			if(player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Wood, 15);
        recipe.AddIngredient(null, "SeaFragment", 5);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
	}
}
