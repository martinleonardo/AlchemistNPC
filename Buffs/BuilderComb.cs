using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class BuilderComb : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Builder Combination");
			Description.SetDefault("Combination of Building, Mining and Calming buffs");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Строителя");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сочетание баффов Строителя, Шахтера и Покоя");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "建筑师药剂包");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "包含以下Buff：镇静, 建筑工, 挖矿");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.pickSpeed -= 0.25f;
			player.calmed = true;
			player.tileSpeed += 0.25f;
            player.wallSpeed += 0.25f;
            ++player.blockRange;
			player.buffImmune[104] = true;
			player.buffImmune[106] = true;
			player.buffImmune[107] = true;
		}
	}
}
