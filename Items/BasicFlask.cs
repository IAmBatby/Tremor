using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BasicFlask : AlchemistItem
	{

		public override void SetDefaults()
		{
			item.crit = 4;
			item.damage = 9;
			//item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("BasicFlaskPro");
			item.shootSpeed = 8f;
			item.useStyle = 1;
			item.knockBack = 1;
			item.UseSound = SoundID.Item106;
			item.value = 30;
			item.rare = 1;
			item.autoReuse = false;
			item.crit = 4;

			item.ammo = mod.ItemType("BoomFlask");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Basic Flask");
			Tooltip.SetDefault("Throws a flask that explodes into clouds");
		}


		public override void PickAmmo(Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			type = mod.ProjectileType("CloudPro");
		}

		public override void UpdateInventory(Player player)
		{
			MPlayer modPlayer = player.GetModPlayer<MPlayer>(mod);
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
			if (player.FindBuffIndex(mod.BuffType("FlaskCoreBuff")) != -1)
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
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(null, "GelCube", 2);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
