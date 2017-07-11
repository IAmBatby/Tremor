using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tremor.Items { [AutoloadEquip(EquipType.Head)]
public class WhiteGoldHelmet : ModItem
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
        item.defense = 30;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("White Gold Helmet");
      Tooltip.SetDefault("Increases ranged damage by 20%\nIncreases melee damage by 20%");
    }


    public override void UpdateEquip(Player player)
    {
        player.rangedDamage += 0.2f;
            player.meleeDamage += 0.2f;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
return body.type == mod.ItemType("WhiteGoldBreastplate") && legs.type == mod.ItemType("WhiteGoldGreaves");
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Shoots dangerous gold daggers";

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
            for(int k = 0; k < Main.npc.Length; k++)
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
                velocity.X = velocity.X + (float)Main.rand.Next(-spread, spread + 1) * spreadMult;
                velocity.Y = velocity.Y + (float)Main.rand.Next(-spread, spread + 1) * spreadMult;
                int i = Projectile.NewProjectile(Main.player[item.owner].Center.X, Main.player[item.owner].Center.Y, velocity.X, velocity.Y, mod.ProjectileType("WhiteGoldKnife"), 100, ShootKN, item.owner);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WhiteGoldBar", 12);
            recipe.SetResult(this);
            recipe.AddTile(null, "DivineForgeTile");
            recipe.AddRecipe();
        }
}}
