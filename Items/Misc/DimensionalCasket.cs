using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC.Interface;

namespace AlchemistNPC.Items.Misc
{
	public class DimensionalCasket : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dimensional Casket");
			Tooltip.SetDefault("Modified Dimensional Casket"
			+"\nAllows to trade with any NPC from any distance"
			+"\nClick to open UI"
			+"\nPress ESC to stop dialing");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Телепортирующая Шкатулка");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Модифицированная межизмеренческая шкатулка\nПозволяет торговать с любым NPC с любого расстояния\nКлик для открытия интерфейса\nНажмите ESC для прекращения связи");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "次元匣");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "修好的次元匣\n允许无视距离与NPC交易\n点击打开UI\n按ESC键关闭");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 5000000;
			Item.rare = 10;
			Item.useStyle = 1;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.consumable = false;
			Item.expert = true;
		}
		
		public override bool? UseItem(Player player)
		{
			if (Main.myPlayer == player.whoAmI)
			{
				DimensionalCasketUI.visible = true;
			}
			return true;
		}
		
		public override bool ConsumeItem(Player player)
		{
			return false;
		}
		
		public override bool CanRightClick()
        {            
            return true;
        }

        public override void RightClick(Player player)
        {
			if (Main.myPlayer == player.whoAmI)
			{
				DimensionalCasketUI.visible = true;
			}
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Items.Materials.BrokenDimensionalCasket>())
				.AddIngredient(ModContent.ItemType<Items.Materials.DivineLava>(), 15)
				.AddRecipeGroup("AlchemistNPC:Tier3Bar", 10)
				.AddIngredient(ItemID.MechanicalBatteryPiece)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
