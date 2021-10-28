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
	public class NULLCD : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("NULL CD");
			Description.SetDefault("");
			Main.debuff[Type] = true;
			CanBeCleared = false;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "NULL перезарядка");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "NULL 再启");
        }
	}
}