using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public abstract class _InvarHelmet : TremorAbstractItem
	{
		public override string Texture => $"{typeof(_InvarHelmet).NamespaceToPath()}/InvarHelmet";

		protected sealed override void Defaults()
		{
			item.width = 32;
			item.height = 26;
			item.value = Item.sellPrice(silver: 9);
			item.rare = 1;
			item.defense = 3;
		}

		protected sealed override void StaticDefaults()
		{
			DisplayName.SetDefault("Invar Helmet");
			Tooltip.SetDefault("+1 defense");
		}

		public override void UpdateEquip(Player player)
		{
			player.statDefense += 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("InvarBreastplate") && legs.type == mod.ItemType("InvarGreaves");
		}
	}

	[AutoloadEquip(EquipType.Head)]
	public class ReinforcedInvarHelmet : _InvarHelmet
	{
		public override void SafeDefaults()
		{
			item.defense += 1;
			item.value = Item.sellPrice(silver: 11);
		}

		public override void SafeStaticDefaults()
		{
			DisplayName.SetDefault("Reinforced Invar Helmet");
			Tooltip.SetDefault(Tooltip.GetDefault() + "\nReinforced to grant +1 defense");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<InvarHelmet>());
			recipe.AddIngredient(mod.ItemType<InvarBar>(), 2);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}

	[AutoloadEquip(EquipType.Head)]
	public class InvarHelmet : _InvarHelmet
	{
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<InvarBar>(), 8);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}

}
