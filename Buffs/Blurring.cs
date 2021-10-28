using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Blurring : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blurring");
			Description.SetDefault("Enemies can barely see you (Shadow Dodge for 10 sec with 30 sec CD)");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Размытие");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Враги едва могут видеть вас (Теневое уклонение с 30-ти секундным откатом)");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "模糊");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "敌人并看不清你 (持续10秒暗影躲避,CD时间30秒)");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
		player.onHitDodge = true;
		if (player.onHitDodge && player.shadowDodgeTimer == 0 && Main.rand.Next(4) == 0)
            {
                if (!player.shadowDodge)
                    player.shadowDodgeTimer = 1800;
                player.AddBuff(59, 600, true);
            }
		}
	}
}
