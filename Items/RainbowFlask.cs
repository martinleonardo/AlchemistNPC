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
     public class RainbowFlask : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flask of Rainbows");
			Tooltip.SetDefault("Your weapons inflict defense destroying and heavy damaging debuffs"
			+"\nRemoves enemy immunity to Ichor, Betsy's Curse and Daybroken");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Флакон Радуги");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ваши оружия разрушают броню вашего противника и накладывают дебаффы, наносящие значительный урон противнику\nУбирает невосприимчивость противника к Ихору, Проклятию Бетси и Дневному Ожогу");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "瓶中彩虹");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "使你的武器造成破甲并且给予许多高伤的Debuff."
            +"\n移除敌人对脓液, 贝特西的诅咒以及破晓的免疫");
        }    
		public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item44;                 //this is the sound that plays when you use the item
            Item.useStyle = 2;                 //this is how the item is holded when used
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = 99;                 //this is where you set the max stack of item
            Item.consumable = true;           //this make that the item is consumable when used
            Item.width = 22;
            Item.height = 34;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 7;
            Item.buffType = ModContent.BuffType<Buffs.RainbowFlaskBuff>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
    }
}
