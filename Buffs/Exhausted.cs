using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Exhausted : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Exhausted");
			Description.SetDefault("You cannot use magic now, lowered horizontal flight speed, decreased melee speed");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			LongerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Истощение");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы не можете использовать магию сейчас, снижена скорость горизонтального полёта, понижена скорость ближнего боя");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "精疲力尽");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "无法使用魔法,降低水平飞行速度,减少近战攻击速度");
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.silence = true;
			player.meleeSpeed -= 0.15f;
            player.statMana = 0;
			player.moveSpeed -= 0.5f;
        }
	}
}
