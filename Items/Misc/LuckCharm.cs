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
	public class LuckCharm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charm of Luck");
			Tooltip.SetDefault("While this is in your inventory, you have better chance of getting better reforges"
			+"\nDoes not affect accessories");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Талисман Удачи");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если находится в инвентаре, вы имеете более высокий шанс получить лучшую перековку\nНе работает с аксессуарами");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "幸运符咒");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放置于物品栏时, 重铸时有更高概率获得更好的词缀\n不能影响饰品");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 1000000;
			Item.rare = 4;
		}
	}
}
