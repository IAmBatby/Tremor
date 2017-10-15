using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public abstract class _InvarHat : TremorAbstractItem
	{
		public override string Texture => $"{typeof(_InvarHat).NamespaceToPath()}/InvarHat";

		protected sealed override void Defaults()
		{
			item.width = 32;
			item.height = 26;
			item.value = Item.sellPrice(silver: 9);
			item.rare = 1;
			item.defense = 2;
		}

		protected sealed override void StaticDefaults()
		{
			DisplayName.SetDefault("Invar Hat");
			Tooltip.SetDefault("10% increased melee speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.1f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType<InvarBreastplate>() && legs.type == mod.ItemType<InvarGreaves>() || body.type == mod.ItemType<ReinforcedInvarBreastplate>() && legs.type == mod.ItemType<ReinforcedInvarGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "10% increased melee speed";
			player.meleeSpeed += 0.1f;
		}
	}

	[AutoloadEquip(EquipType.Head)]
	public class ReinforcedInvarHat : _InvarHat
	{
		public override void SafeDefaults()
		{
			item.defense += 1;
			item.value = Item.sellPrice(silver: 11);
		}

		public override void SafeStaticDefaults()
		{
			DisplayName.SetDefault("Reinforced Invar Hat");
			Tooltip.SetDefault(Tooltip.GetDefault() + "\nReinforced to grant +1 defense");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<InvarHat>());
			recipe.AddIngredient(mod.ItemType<InvarBar>(), 2);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}

	[AutoloadEquip(EquipType.Head)]
	public class InvarHat : _InvarHat
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
