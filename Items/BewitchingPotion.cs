using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
 
namespace AlchemistNPC.Items
{
     public class BewitchingPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bewitching Potion");
			Tooltip.SetDefault("Grants Bewitched buff (increases max number of minions)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Зелье Колдовства");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт бафф Колдовства (увеличивает максимальное число прислужников)");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "迷人药剂");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加召唤物能力 (增加一个召唤物上限)");
        }    
		public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item3;                 //this is the sound that plays when you use the item
            Item.useStyle = 2;                 //this is how the item is holded when used
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = 99;                 //this is where you set the max stack of item
            Item.consumable = true;           //this make that the item is consumable when used
            Item.width = 20;
            Item.height = 30;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.rare = 7;
            Item.buffType = 150;           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Moonglow, 1)
				.AddIngredient(ItemID.Deathweed, 1)
				.AddIngredient(ItemID.Stinger, 1)
				.AddIngredient(ItemID.Vine, 1)
				.AddIngredient(ItemID.JungleSpores, 1)
				.AddIngredient(ItemID.BottledWater, 1)
				.AddTile(TileID.Bottles)
				.Register();
		}
    }
}
