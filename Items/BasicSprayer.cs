using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BasicSprayer : AlchemistItem
	{

		public override void SetDefaults()
		{

			item.damage = 16;
			item.width = 68;
			item.height = 30;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = 10;
			item.shootSpeed = 6f;
			item.crit = 4;
			item.useAmmo = mod.ItemType("BoomFlask");

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Basic Sprayer");
			Tooltip.SetDefault("Uses flasks as ammo\n" +
"Sprays alchemical clouds");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 45);
			recipe.AddIngredient(null, "BasicFlask", 8);
			recipe.AddIngredient(ItemID.ShadowScale, 15);
			recipe.AddIngredient(ItemID.IronBar, 18);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 45);
			recipe.AddIngredient(null, "BasicFlask", 8);
			recipe.AddIngredient(ItemID.TissueSample, 15);
			recipe.AddIngredient(ItemID.IronBar, 18);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 45);
			recipe.AddIngredient(null, "BasicFlask", 8);
			recipe.AddIngredient(ItemID.ShadowScale, 15);
			recipe.AddIngredient(ItemID.LeadBar, 18);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 45);
			recipe.AddIngredient(null, "BasicFlask", 8);
			recipe.AddIngredient(ItemID.TissueSample, 15);
			recipe.AddIngredient(ItemID.LeadBar, 18);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}

		public override bool ConsumeAmmo(Player player)
		{
			if (player.FindBuffIndex(mod.BuffType("EnchantmentSolution")) != -1)
			{
				if (Main.rand.Next(0, 100) <= 50)
					return false;
			}
			if (player.FindBuffIndex(mod.BuffType("AmplifiedEnchantmentSolution")) != -1)
			{
				if (Main.rand.Next(0, 100) <= 70)
					return false;
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
		}

		public override void UpdateInventory(Player player)
		{
			MPlayer modPlayer = MPlayer.GetModPlayer(player);
			if (modPlayer.core)
			{
				item.autoReuse = true;
			}
			if (!modPlayer.core)
			{
				item.autoReuse = false;
			}
			if (player.FindBuffIndex(mod.BuffType("LongFuseBuff")) != -1)
			{
				item.shootSpeed = 14f;
			}
			if (player.FindBuffIndex(mod.BuffType("LongFuseBuff")) < 1)
			{
				item.shootSpeed = 6f;
			}
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			MPlayer modPlayer = MPlayer.GetModPlayer(player);
			if (modPlayer.glove)
			{
				for (int i = 0; i < 1; ++i)
				{
					if (player.FindBuffIndex(mod.BuffType("BottledSpirit")) != -1)
					{
						Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + 2, 297, damage, knockBack, Main.myPlayer);
					}
					if (player.FindBuffIndex(mod.BuffType("BigBottledSpirit")) != -1)
					{
						Projectile.NewProjectile(position.X, position.Y, speedX + 3, speedY + 3, 297, damage, knockBack, Main.myPlayer);
						Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + 2, 297, damage, knockBack, Main.myPlayer);
					}
					Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockBack, Main.myPlayer);
					Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockBack, Main.myPlayer);
					int k = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
					Main.projectile[k].friendly = true;
				}
				return false;
			}
			if (player.FindBuffIndex(mod.BuffType("BottledSpirit")) != -1 && !modPlayer.glove)
			{
				for (int i = 0; i < 1; ++i)
				{
					Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, 297, damage, knockBack, Main.myPlayer);
					int k = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
					Main.projectile[k].friendly = true;
				}
				return false;
			}
			if (player.FindBuffIndex(mod.BuffType("BigBottledSpirit")) != -1 && !modPlayer.glove)
			{
				for (int i = 0; i < 1; ++i)
				{
					Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + 2, 297, damage, knockBack, Main.myPlayer);
					Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, 297, damage, knockBack, Main.myPlayer);
					int k = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
					Main.projectile[k].friendly = true;
				}
				return false;
			}
			return true;
		}
	}
}
