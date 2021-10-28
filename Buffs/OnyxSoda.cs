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
	public class OnyxSoda : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Onyx Soda");
			Description.SetDefault("Increases endurance by 75%");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ониксовая Сода");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает вашу стойкость на 75%");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "玛瑙苏打加持");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加75%耐力");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.endurance += 0.75f;
		}
	}
}
