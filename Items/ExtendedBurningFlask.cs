using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ExtendedBurningFlask : AlchemistItem
	{

		public override void SetDefaults()
		{
			item.crit = 4;
			item.damage = 42;
			//item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("ExtendedBurningFlaskPro");
			item.shootSpeed = 8f;
			item.useStyle = 1;
			item.knockBack = 1;
			item.UseSound = SoundID.Item106;
			item.value = 120;
			item.rare = 1;
			item.autoReuse = false;


			item.ammo = mod.ItemType("BoomFlask");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Extended Burning Flask");
			Tooltip.SetDefault("Throws a flask that explodes into clouds\nClouds deal damage to enemies and burn them");
		}


		public override void PickAmmo(Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			type = mod.ProjectileType("FieryCloudPro");
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
			recipe.AddIngredient(null, "BurningFlask", 45);
			recipe.AddIngredient(null, "FireFragment", 1);
			recipe.AddIngredient(ItemID.SoulofLight, 1);
			recipe.AddIngredient(null, "GelCube", 1);
			recipe.SetResult(this, 30);
			recipe.AddRecipe();
		}
	}
}
