using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class NovaHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 30;


			item.rare = 10;
			item.defense = 14;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Helmet");
			Tooltip.SetDefault("Increases alchemic damage by 12%\nIncreases alchemic critical strike chance by 12\nEnemies are more likely to target you");
		}


		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemistCrit += 12;
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.12f;
			player.aggro += 10;
			Lighting.AddLight((int)((player.position.X + player.width / 2) / 16f), (int)((player.position.Y + player.height / 2) / 16f), 0.8f, 0.7f, 0.3f);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("NovaBreastplate") && legs.type == mod.ItemType("NovaLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases alchemic damage by 15% and summons alchemical cauldron to protect you";
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.15f;
			player.GetModPlayer<MPlayer>(mod).novaSet = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("NovaCauldron")] < 1)
			{
				Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("NovaCauldron"), 50, 0, player.whoAmI);
			}
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
			player.armorEffectDrawOutlines = true;
			player.armorEffectDrawShadowLokis = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NovaFragment", 10);
			recipe.AddIngredient(3467, 8);
			recipe.AddTile(412);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
