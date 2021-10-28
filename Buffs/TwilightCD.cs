using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class TwilightCD : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight Cooldown");
			Description.SetDefault("You cannot use Twilight's special ability yet");
			Main.debuff[Type] = true;
			CanBeCleared = false;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумеречная Перезарядка");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы пока не можете использовать специальную способность Сумерек");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蕾蒂希娅冷却");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "无法使用蕾蒂希娅的特殊能力");
        }
	}
}
