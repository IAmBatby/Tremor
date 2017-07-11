using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class DesertExplorerGreaves : ModItem
	{
		private static short glowMaskIndex;

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 22;


			item.value = 13500;
			item.rare = 8;
			item.defense = 13;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Explorer Greaves");
			Tooltip.SetDefault("Increases alchemic damage by 11%\nIncreases movement speed by 30%");
			glowMaskIndex=TremorGlowMask.AddGlowMask("Tremor/Items/DesertExplorerGreaves_LegsGlow");
		}


		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.16f;
			player.moveSpeed += 0.3f;
		}

		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
		{
			glowMask = glowMaskIndex;
			glowMaskColor = Color.White;
		}
	}
}
