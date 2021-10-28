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
     public class NatureBlessingPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nature Blessing Potion");
			Tooltip.SetDefault("Grants Dryad's Blessing buff");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Зелье Благословления Природы");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт бафф Благословления Дриады");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "自然祝福药剂");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "获得树妖的祝福Buff");
        }    
		public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item3;
            Item.useStyle = 2;
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.width = 20;
            Item.height = 30;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = 2;
            Item.buffType = 165;
            Item.buffTime = 36000;
            return;
        }
    }
}
