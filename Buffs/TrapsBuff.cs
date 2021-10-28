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
	public class TrapsBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Traps Buff");
			Description.SetDefault("Traps are empowered");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усилитель ловушек");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ловушки значительно усилены");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "陷阱增强");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增强陷阱");
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
		((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).Traps = true;
		}
	}
}
