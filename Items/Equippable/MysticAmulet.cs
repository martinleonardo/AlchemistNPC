using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class MysticAmulet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystic Amulet");
			Tooltip.SetDefault("Grants Telekinesis ability to its wielder"
				+ "\nCan be used for flying");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Мистический Амулет");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт носителю способность к Телекинезу\nПозволяет летать");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "神秘护符");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "使使用者获得心灵促动的能力\n可用来飞行");
        }    
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.BlessedApple);
			Item.width = 32;
			Item.height = 30;
			Item.value = 5000000;
			Item.rare = 11;
			Item.mountType = MountType<Mounts.MysticAmulet>();
		}
	}
}
