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
	public class SapphireSoda : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sapphire Soda");
			Description.SetDefault("Removes Mana Sickness debuff");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сапфировая Сода");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Убирает дебафф Ослабление Волшебства");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "宝蓝苏打加持");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "移除魔力病Debuff");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.buffImmune[94] = true;
		}
	}
}
