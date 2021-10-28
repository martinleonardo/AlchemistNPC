using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class GreaterDangersense : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Greater Dangersense");
			Description.SetDefault("Lights up enemy projectiles");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Зелье Великого Чувства Опасности");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Подсвечивает снаряды противника");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "强效危险感知");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "高亮敌人的抛射物");
        }
	}
}
