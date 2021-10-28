using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
    public class ReversivityCoinTier1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reversivity Coin Tier 1");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монета Реверсии Первого Уровня");
            Tooltip.SetDefault("Can be used for buying Treasure Bags from Operator");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Может быть использована для покупки сумок у Оператора");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "逆转硬币 T-1");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "可以用来在操作员处购买宝藏袋");
        }
        public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.value = 10000;
			Item.rare = 8;
		}
        public override void AddRecipes()
        {
            CreateRecipe(2)
            	.AddIngredient(null, "ReversivityCoinTier2", 1)
            	.AddTile(TileID.MythrilAnvil)
            	.Register();
        }
    }
}