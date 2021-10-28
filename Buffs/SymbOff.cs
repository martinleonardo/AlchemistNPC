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
	public class SymbOff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Symbiote Offense Mode");
			Description.SetDefault("Increased attack speed");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Атакующий режим симбиота");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Скорость атаки увеличена");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "共生体攻击模式");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加攻击速度");
        }
	}
}
