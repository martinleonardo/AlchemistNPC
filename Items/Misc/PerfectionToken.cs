using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class PerfectionToken : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Perfection Token");
			Tooltip.SetDefault("While this is in your inventory, your next weapon/tool reforge would get best possible result"
			+"\nConsumes in process"
			+"\nNot compatible with Thorium Mod's Bard and Healer items");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Значок Совершенства");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если находится в инвентаре, ваше следующая перековка будет иметь наилучший результат\nБудет потрачен в процессе\nНесовместим с предметами Барда и Лекаря из Ториума");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "完美重铸币");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放置于物品栏时, 武器/工具下一次重铸时获得完美词缀(炼金术士mod特有的传说级词缀)\n在过程中将会被消耗\n不兼容瑟银的乐师和牧师物品");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 1000000;
			Item.maxStack = 99;
			Item.rare = 5;
		}
	}
}
