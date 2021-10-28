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
    public class SapphireBlueberrySoda : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sapphire Blueberry Soda");
			Tooltip.SetDefault("Restores 200 mana, removes Mana Sickness for a short time.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сода Сапфировой Голубики");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Восстанавливает 200 маны, убирает Магическую слабость в течении короткого времени");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "宝蓝蓝莓苏打水");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "恢复200点法力值, 短时间内移除法力病Debuff.");
        }    
		public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SuperManaPotion);
            Item.maxStack = 999;
            Item.consumable = true;
            Item.value = 0;
            Item.rare = 6;
			Item.healMana = 200;
            return;
        }
		
		public override bool? UseItem(Player player)
		{
			player.AddBuff(ModContent.BuffType<Buffs.SapphireSoda>(), 900);
			return true;
		}
    }
}
