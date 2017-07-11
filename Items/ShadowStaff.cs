using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ShadowStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 34;
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
			item.value = Item.buyPrice(0, 9, 0, 0);
			item.rare = 7;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("ShadowStaffPro");
			item.shootSpeed = 2f;
			item.buffType = mod.BuffType("ShadowArmBuff");
			item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Staff");
			Tooltip.SetDefault("Summons a shadow arm to fight for you.");
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
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddIngredient(ItemID.SpookyWood, 15);
			recipe.AddIngredient(null, "DarknessCloth", 9);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
