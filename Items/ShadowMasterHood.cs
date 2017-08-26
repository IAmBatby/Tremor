using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class ShadowMasterHood : ModItem
	{
		const int ShootType = ProjectileID.HeatRay; // ��� ��������
		const float ShootRange = 600.0f; // ��������� ��������
		const float ShootKN = 1.0f; // ������������ 
		const int ShootRate = 120; // ������� �������� (60 - 1 �������)
		const int ShootCount = 2; // ������� �� �������
		const float ShootSpeed = 20f; // �������� �������� (��� ������ - ���������)
		const int spread = 45; // �������
		const float spreadMult = 0.045f; // ����������� ��������

		int TimeToShoot = ShootRate;



		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;


			item.value = 10000;
			item.rare = 11;
			item.defense = 18;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Master Hood");
			Tooltip.SetDefault("Increases alchemic damage by 25%\nIncreases throwing damage by 15%");
		}


		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.2f;
			player.thrownDamage += 0.25f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ShadowMasterChestplate") && legs.type == mod.ItemType("ShadowMasterPants");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Creates dangerous alchemical bubbles and increases alchemic critical strike chance by 35";
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 35;

			if (--TimeToShoot <= 0)
			{
				TimeToShoot = ShootRate;
				int Target = GetTarget();
				if (Target != -1) Shoot(Target, GetDamage());
			}
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
				int i = Projectile.NewProjectile(Main.player[item.owner].Center.X, Main.player[item.owner].Center.Y, velocity.X, velocity.Y, mod.ProjectileType("AlchemicBubble"), 100, ShootKN, item.owner);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrokenHeroArmorplate", 1);
			recipe.AddIngredient(ItemID.Silk, 15);
			recipe.AddIngredient(null, "SoulofFight", 10);
			recipe.AddIngredient(null, "DarkGel", 15);
			recipe.AddIngredient(null, "DarknessCloth", 6);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
