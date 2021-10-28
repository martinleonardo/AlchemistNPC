using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
	public class CloakOfFearDebuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cloak Of Fear Debuff");
			Description.SetDefault("Make nearby non-boss enemies change their movement direction");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			LongerExpertDebuff = false;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Дебафф Плаща Страха");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Заставляет обычных врагов около игрока менять направление движения");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "恐惧之袍Debuff");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "使附近的非Boss敌人改变移动方向");
        }
		
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.confused = true;
		}
	}
}
