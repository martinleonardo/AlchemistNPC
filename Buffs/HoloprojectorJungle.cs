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
	public class HoloprojectorJungle : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holoprojector ''Jungle''");
			Description.SetDefault("Biome state is set to Jungle now");
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Голографический Проектор ''Джунгли''");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Изменяет текущий биом на Джунглевый");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "全息投影仪 ''丛林''");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "当前地形设置:丛林");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.ZoneJungle = true;
		}
	}
}
