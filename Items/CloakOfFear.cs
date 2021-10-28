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
    public class CloakOfFear : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scroll ''Cloak of Fear''");
			Tooltip.SetDefault("One-use item"
			+"\nContains the spell ''Cloak of Fear''"
			+"\nMakes nearby non-boss enemies change their movement direction"
			+"\nExhausts player for 30 seconds after effect ends, making him unable to use magic");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Свиток ''Плащ Страха''");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Одноразовый предмет\nЭтот свиток содержит заклинание ''Плащ Страха''\nЗаставляет противников вблизи игрока изменять направление движения\nИстощает игрока на 30 секунд после окончания действия, не позволяя ему использовать магию");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "卷轴 ''恐惧之袍''");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "一次性物品"
			+"\n包含着 ''恐惧之袍''法术"
			+"\n使附近的非Boss敌人改变移动方向"
			+"\n使玩家精疲力尽1分钟, 期间无法使用魔法");
        }
		
		public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item123;
            Item.useStyle = 2;
            Item.useTurn = true;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.width = 18;
            Item.height = 28;
            Item.value = Item.sellPrice(1, 0, 0, 0);
            Item.rare = 11;
			Item.mana = 200;
        }
		
		public override bool? UseItem(Player player)
		{
			player.AddBuff(ModContent.BuffType<Buffs.CloakOfFear>(), 10800);
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (!player.HasBuff(ModContent.BuffType<Buffs.Exhausted>()) && !player.HasBuff(ModContent.BuffType<Buffs.ExecutionersEyes>()) && !player.HasBuff(ModContent.BuffType<Buffs.CloakOfFear>()))
			{
				return true;
			}
			return false;
		}
    }
}
