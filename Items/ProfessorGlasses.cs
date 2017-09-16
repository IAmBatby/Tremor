using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class ProfessorGlasses : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 10;
			item.value = 100;
			item.rare = 2;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Professor Glasses");
			Tooltip.SetDefault("");
		}

		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}
	}
}
