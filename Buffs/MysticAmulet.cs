using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class MysticAmulet : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Mystic Amulet");
			Description.SetDefault("Allows to fly freely");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Мистический Амулет");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Позволяет свободно летать");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "神秘护符");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "可以自由飞翔");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			//player.mount.SetMount(Mod.MountType("MysticAmulet"), player);
			player.mount.SetMount(ModContent.MountType<Mounts.MysticAmulet>(), player);
			player.buffTime[buffIndex] = 10;
			player.noKnockback = true;
			player.noFallDmg = true;
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			modPlayer.MysticAmuletMount = true;
			modPlayer.fc++;
			if (modPlayer.fc == 40)
			{
				modPlayer.fc = 0;
			}
		}
	}
}
