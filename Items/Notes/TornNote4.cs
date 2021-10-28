using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class TornNote4 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #4");
			Tooltip.SetDefault("''Defeating the Moon Lord allows the creation of Ultimate Accessories."
			+"\nOne of them is the Sephirothic Fruit." 
			+"\nNot only does it increase your minion damage by 15% and give +2 max minions..."
			+"\nBut it also allows your minions to ignore invincibility frames''"
			+"\nThere seems to be something important, but you can't read it yet. Not without other parts. Maybe Jeweler can help you.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Изорванная записка #4");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "'После победы на Лунным Лордом ты сможешь скрафтить Ультимативные Аксессуары.\nОдин из них - это Плод Сефирот.\nОн не только увеливает урон прислужников на 15% и дает 2 дополнительных слота для прислужников...\nНо так же он позволяет прислужникам игнорировать период неуязвимости противника.'\nЗдесь ещё есть что-то важное, но вы не можете это прочесть. Не без других частей.\nВозможно, Ювелир сможет помочь.");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "破损的笔记 #4");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'在击败月亮领主之后, 你可以制造一些终极饰品." +
                "\n其中之一是瑟芙罗克之果." +
                "\n它不仅使你的召唤伤害增加10%并且+2最大召唤物数量..." +
                "\n同时也会使得你的召唤物无视敌人无敌帧'" +
                "\n还有一些内容, 但是你并读不到. 除非你有其它碎片. 也许珠宝师可以帮助你.");
        }

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 36;
			Item.maxStack = 99;
			Item.value = 150000;
			Item.rare = 5;
		}
	}
}
