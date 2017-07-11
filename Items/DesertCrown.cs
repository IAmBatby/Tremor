using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {

public class DesertCrown : ModItem
{
    public override void SetDefaults()
    {

        item.width = 24;
        item.height = 16;
        item.maxStack = 20;

        item.rare = 2;
        item.useAnimation = 45;
        item.useTime = 45;
        item.useStyle = 4;
item.value = 50000;
        item.consumable = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Desert Crown");
      Tooltip.SetDefault("Summons the Rukh");
    }


    public override bool CanUseItem(Player player)
    {
        return !NPC.AnyNPCs(mod.NPCType("npcVultureKing")) && player.ZoneDesert;
    }

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("npcVultureKing"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.GoldCrown);
        recipe.AddIngredient(ItemID.AntlionMandible, 5);
        recipe.AddIngredient(null, "AntlionShell", 3);
        recipe.AddIngredient(ItemID.SandBlock, 15);
        recipe.AddTile(16);
        recipe.SetResult(this);
        recipe.AddRecipe();

        recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.PlatinumCrown);
        recipe.AddIngredient(ItemID.AntlionMandible, 5);
        recipe.AddIngredient(null, "AntlionShell", 3);
        recipe.AddIngredient(ItemID.SandBlock, 15);
        recipe.AddTile(16);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}
