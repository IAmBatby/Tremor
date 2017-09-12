using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class DesertExplorerVisage : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 22;

			item.value = 15000;
			item.rare = 8;
			item.defense = 11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Explorer Visage");
			Tooltip.SetDefault("15% increased alchemical critical strike chance");
			TremorGlowMask.AddGlowMask(item.type, "Tremor/Items/DesertExplorerVisage_HeadGlow");
		}


		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
			player.armorEffectDrawOutlines = true;
		}

		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
		{
			glowMaskColor = Color.White;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 15;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("DesertExplorerBreastplate") && legs.type == mod.ItemType("DesertExplorerGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "When a flask explodes a wasp appears to attack enemies";
			player.AddBuff(mod.BuffType("DesertEmperorSetBuff"), 4);
		}
	}
}
