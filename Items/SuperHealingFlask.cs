using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SuperHealingFlask : AlchemistItem
	{
		public override void SetDefaults()
		{
			item.crit = 4;
			item.damage = 96;
			item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("SuperHealingFlaskPro");
			item.shootSpeed = 8f;
			item.useStyle = 1;
			item.knockBack = 1;
			item.UseSound = SoundID.Item106;
			item.value = 7;

			item.rare = 8;
			item.autoReuse = false;
			item.ammo = mod.ItemType("BoomFlask");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Super Healing Flask");
			Tooltip.SetDefault("Throws a flask that explodes into clouds\nClouds deal damage to enemies and restore health");
		}

		public override void PickAmmo(Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			type = mod.ProjectileType("HealingCloudPro");
		}

		public override void UpdateInventory(Player player)
		{
			MPlayer modPlayer = MPlayer.GetModPlayer(player);
			if (modPlayer.novaHelmet)
			{
				item.autoReuse = true;
			}
			if (!modPlayer.novaHelmet)
			{
				item.autoReuse = false;
			}

			if (player.FindBuffIndex(mod.BuffType("LongFuseBuff")) != -1)
			{
				item.shootSpeed = 11f;
			}
			if (player.FindBuffIndex(mod.BuffType("LongFuseBuff")) < 1)
			{
				item.shootSpeed = 8f;
			}
			if (modPlayer.core)
			{
				item.autoReuse = true;
			}
			if (player.FindBuffIndex(mod.BuffType("FlaskCoreBuff")) < 1)
			{
				item.autoReuse = false;
			}
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BigHealingFlack", 20);
			recipe.AddIngredient(3456, 1);
			recipe.AddIngredient(null, "AngryShard", 1);
			recipe.SetResult(this, 20);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BigHealingFlack", 20);
			recipe.AddIngredient(3457, 1);
			recipe.AddIngredient(null, "AngryShard", 1);
			recipe.SetResult(this, 20);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BigHealingFlack", 20);
			recipe.AddIngredient(3458, 1);
			recipe.AddIngredient(null, "AngryShard", 1);
			recipe.SetResult(this, 20);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BigHealingFlack", 20);
			recipe.AddIngredient(3459, 1);
			recipe.AddIngredient(null, "AngryShard", 1);
			recipe.SetResult(this, 20);
			recipe.AddRecipe();
		}

	}
}
