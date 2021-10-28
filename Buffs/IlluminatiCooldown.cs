using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class IlluminatiCooldown : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Illuminati Gift's cooldown");
			Description.SetDefault("Illuminati Gift's effect cannot be activated");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			LongerExpertDebuff = false;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Откат Дара Иллюминатов");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Эффект Дара Иллюминатов не может быть активирован");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "光照会礼物 冷却");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "无法激活光照会礼物的效果");
        }
	}
}
