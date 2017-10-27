using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Desert
{
	[AutoloadEquip(EquipType.Legs)]
	public class DesertExplorerGreaves : ModItem
	{
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
			Tooltip.SetDefault("16% increased alchemical damage\n" +
			                   "30% increased movement speed");
			TremorGlowMask.AddGlowMask(item.type, $"{typeof(DesertExplorerGreaves).NamespaceToPath()}/DesertExplorerGreaves_LegsGlow");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.16f;
			player.moveSpeed += 0.3f;
			player.maxRunSpeed += 0.3f;
		}

		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
		{
			glowMaskColor = Color.White;
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{

		}
	}
}
