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
    public class CrimsonCherrySoda : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimson Cherry Soda");
			Tooltip.SetDefault("Heals for 175 hp and increases life regeneration greatly for a short time.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Алая Вишневая Сода");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Лечит на 175 HP и значительно увеличивает регенерацию на короткое время");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "绯红樱桃苏打水");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "恢复175点生命值, 并在短时间内极大增加生命恢复速度.");
        }    
		public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SuperHealingPotion);
            Item.maxStack = 99;                 //this is where you set the max stack of item
            Item.consumable = true;           //this make that the item is consumable when used
            Item.value = 0;
            Item.rare = 6;
			Item.healLife = 175;
			Item.potion = true;
            return;
        }
		
		public override bool? UseItem(Player player)
		{
			player.AddBuff(ModContent.BuffType<Buffs.CrimsonSoda>(), 2700);
			return true;
		}
    }
}
