using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class CrimsonSoda : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimson Soda");
			Description.SetDefault("Greatly increases life regeneration");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Алая Сода");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Значительно увеличивает регенерацию здоровья");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "绯红苏打加持");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "极大增加生命回复速度");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.lifeRegen += 10;
		}
	}
}
