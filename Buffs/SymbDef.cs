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
	public class SymbDef : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Symbiote Defense Mode");
			Description.SetDefault("Increased life regeneration, defense and damage reduction");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Защитный режим симбиота");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Регенерация, сопротивление урона и защита увеличены");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "共生体防御模式");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加生命回复, 防御和伤害减免");
        }
	}
}
