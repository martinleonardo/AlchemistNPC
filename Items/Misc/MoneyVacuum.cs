using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class MoneyVacuum : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart of Greed");
			Tooltip.SetDefault("While in your inventory, all money dropped goes in your inventory");

			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "贪欲之心");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "在你的背包中时，所有掉落的钱币都会吸进你的背包");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 1000000;
			Item.rare = 5;
		}
		
		public override void UpdateInventory(Player player)
		{
			for (int number = 0; number < 400; ++number)
			{
				if (Main.item[number].active && Main.item[number].type == 71)
				{
					Main.item[number] = player.GetItem(player.whoAmI, Main.item[number], GetItemSettings.PickupItemFromWorld);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				else if (Main.item[number].active && Main.item[number].type == 72)
				{
					Main.item[number] = player.GetItem(player.whoAmI, Main.item[number], GetItemSettings.PickupItemFromWorld);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				else if (Main.item[number].active && Main.item[number].type == 73)
				{
					Main.item[number] = player.GetItem(player.whoAmI, Main.item[number], GetItemSettings.PickupItemFromWorld);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				else if (Main.item[number].active && Main.item[number].type == 74)
				{
					Main.item[number] = player.GetItem(player.whoAmI, Main.item[number], GetItemSettings.PickupItemFromWorld);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
					}
				}
			}
		}
		
		public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.CrimsonHeart)
				.AddIngredient(ItemID.GoldRing)
				.AddIngredient(ModContent.ItemType<Items.Materials.BrokenDimensionalCasket>())
				.AddIngredient(ItemID.HallowedBar, 10)
				.AddIngredient(ModContent.ItemType<Items.Materials.DivineLava>(), 15)
				.Register();
			
			CreateRecipe()
				.AddIngredient(ItemID.ShadowOrb)
				.AddIngredient(ItemID.GoldRing)
				.AddIngredient(ModContent.ItemType<Items.Materials.BrokenDimensionalCasket>())
				.AddIngredient(ItemID.HallowedBar, 10)
				.AddIngredient(ModContent.ItemType<Items.Materials.DivineLava>(), 15)
				.Register();
        }
	}
}
