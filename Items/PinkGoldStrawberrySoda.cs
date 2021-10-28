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
    public class PinkGoldStrawberrySoda : ModItem
    {
        public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Pink Gold Strawberry Soda");
		Tooltip.SetDefault("Heals for 150 hp and 150 mana, removes most debuffs for a short time");
		DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сода Розово-Золотой Клубники");
        Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пополняет 150 жизней и маны, убирает большинство дебаффов в течение короткого времени");
		
        DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "桃金草莓苏打水");
        Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "恢复150点生命值和150点法力值, 短时间内移除大部分Debuff");
        }    
		public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SuperHealingPotion);
            Item.maxStack = 99;                 //this is where you set the max stack of item
            Item.consumable = true;           //this make that the item is consumable when used
            Item.value = 0;
            Item.rare = 6;
			Item.healLife = 150;
			Item.healMana = 150;
			Item.potion = true;
            return;
        }
		
		public override bool? UseItem(Player player)
		{
			player.AddBuff(ModContent.BuffType<Buffs.PinkGoldSoda>(), 600);
			return true;
		}
    }
}
