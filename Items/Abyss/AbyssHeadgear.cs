using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Abyss
{
	[AutoloadEquip(EquipType.Head)]
	public class AbyssHeadgear : ModItem
	{

		const int ShootType = 496; 
		const float ShootRange = 100.0f; 
		const float ShootKN = 1.0f; 
		const int ShootRate = 60; 
		const int ShootCount = 3; 
		const float ShootSpeed = 15f; 
		const int spread = 45; 
		const float spreadMult = 0.045f; 

		int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 18000;
			item.rare = 7;
			item.defense = 11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abyss Headgear");
			Tooltip.SetDefault("14% increased minion damage\n" +
"Increases maximum health by 40");
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.14f;
			player.statLifeMax2 += 40;

		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("AbyssBreastplate") && legs.type == mod.ItemType("AbyssGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Allows to see hazards\n" +
"Summons abyss magic to attack nearby enemies\n" +
"Your Shadow Arms has 33% chance to inflict Shadowflame on enemies";
			TremorPlayer modPlayer = player.GetModPlayer<TremorPlayer>(mod);
			modPlayer.shadowArmSF = true;
			player.dangerSense = false;

			if (--TimeToShoot <= 0)
			{
				TimeToShoot = ShootRate;
				int Target = GetTarget();
				if (Target != -1) Shoot(Target, GetDamage());
			}

			if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame) // Makes sure the player is actually moving
			{
				for (int k = 0; k < 2; k++)
				{
					int index = Dust.NewDust(new Vector2(player.position.X - player.velocity.X * 2f, player.position.Y - 2f - player.velocity.Y * 2f), player.width, player.height, 65, 0f, 0f, 100, default(Color), 2f);
					Main.dust[index].noGravity = true;
					Main.dust[index].noLight = true;
					Dust dust = Main.dust[index];
					dust.velocity.X = dust.velocity.X - player.velocity.X * 0.5f;
					dust.velocity.Y = dust.velocity.Y - player.velocity.Y * 0.5f;
				}
			}
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		int GetTarget()
		{
			int Target = -1;
			for (int k = 0; k < Main.npc.Length; k++)
			{
				if (Main.npc[k].active && Main.npc[k].lifeMax > 5 && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].Distance(Main.player[item.owner].Center) <= ShootRange && Collision.CanHitLine(Main.player[item.owner].Center, 4, 4, Main.npc[k].Center, 4, 4))
				{
					Target = k;
					break;
				}
			}
			return Target;
		}

		int GetDamage()
		{
			return (10 * ((int)Main.player[item.owner].magicDamage + (int)Main.player[item.owner].meleeDamage + (int)Main.player[item.owner].minionDamage + (int)Main.player[item.owner].rangedDamage + (int)Main.player[item.owner].thrownDamage)) + 15;
		}

		void Shoot(int Target, int Damage)
		{
			Vector2 velocity = Helper.VelocityToPoint(Main.player[item.owner].Center, Main.npc[Target].Center, ShootSpeed);
			for (int l = 0; l < ShootCount; l++)
			{
				velocity.X = velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
				velocity.Y = velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;
				int i = Projectile.NewProjectile(Main.player[item.owner].Center.X, Main.player[item.owner].Center.Y, velocity.X, velocity.Y, ShootType, Damage, ShootKN, item.owner);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarknessCloth", 11);
			recipe.AddIngredient(ItemID.SoulofNight, 9);
			recipe.AddIngredient(ItemID.Amethyst, 7);
			recipe.AddIngredient(null, "PhantomSoul", 4);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}

	}
}
