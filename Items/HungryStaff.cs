using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class HungryStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 23;
			item.summon = true;
			item.mana = 15;
			item.width = 26;
			item.height = 28;

			item.useTime = 36;
			item.channel = true;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 3, 0, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("HungryStaffPro");
			item.shootSpeed = 2f;
			item.buffType = mod.BuffType("HungryBuff");
			item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hungry Staff");
			Tooltip.SetDefault("Summons a hungry to fight for you.");
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
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PieceofFlesh", 9);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
