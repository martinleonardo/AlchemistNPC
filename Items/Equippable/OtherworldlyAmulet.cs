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
	public class OtherworldlyAmulet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Otherworldly Amulet");
			Tooltip.SetDefault("Only obtainable from the strongest of enemies."
				+ "\nLegends say that it can do something amazing");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(25, 36));
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Амулет Иного Мира");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Можно добыть из сильнейшего из врагов.\nЛегенды говорят, что он способен на нечто впечатляющее");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "异界护身符");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "只能从最强大的敌人那里得到\n传说可以用它做一些了不起的事情");
        }    
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.BlessedApple);
			Item.width = 32;
			Item.height = 30;
			Item.value = 5000000;
			Item.rare = 11;
			Item.noUseGraphic = true;
			Item.mountType = MountType<Mounts.Poro>();
		}
	}
}
