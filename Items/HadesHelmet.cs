using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class HadesHelmet : ModItem
	{

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.value = 400;
			item.rare = 250000;
			item.defense = 35;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hades Helmet");
			Tooltip.SetDefault("Melee attacks inflict fire damage\n30% decreased mana cost\nIncreases maximum life by 150");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "InfernoSoul", 5);
			recipe.AddIngredient(null, "MagmoniumHelmet", 1);
			recipe.AddIngredient(null, "FireFragment", 15);
			recipe.AddIngredient(null, "Phantaplasm", 8);
			recipe.AddIngredient(ItemID.LivingFireBlock, 6);
			recipe.SetResult(this);
			recipe.AddTile(null, "StarvilTile");
			recipe.AddRecipe();
		}

		public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

		public override void UpdateEquip(Player player)
		{
			player.magmaStone = true;
			player.manaCost -= 0.3f;
			player.statLifeMax2 += 150;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
			player.armorEffectDrawOutlines = true;
			player.armorEffectDrawShadowLokis = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("HadesBreastplate") && legs.type == mod.ItemType("HadesGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Summons a molten watcher to protect you";
			player.AddBuff(mod.BuffType("MoltenWatcherBuff"), 2);

			if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame) // Makes sure the player is actually moving
			{
				for (int k = 0; k < 2; k++)
				{
					int index = Dust.NewDust(new Vector2(player.position.X - player.velocity.X * 2f, player.position.Y - 2f - player.velocity.Y * 2f), player.width, player.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[index].noGravity = true;
					Main.dust[index].noLight = true;
					Dust dust = Main.dust[index];
					dust.velocity.X = dust.velocity.X - player.velocity.X * 0.5f;
					dust.velocity.Y = dust.velocity.Y - player.velocity.Y * 0.5f;
				}
			}
		}
	}
}
