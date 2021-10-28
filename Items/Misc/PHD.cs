using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class PHD : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PhD Degree Diploma");
			Tooltip.SetDefault("Use to permanently upgrade your Nurse"
			+"\nOpens up healing interface after respawn"
			+"\nThis effect is global for all players in this world"
			+"\nWould work only if Nurse is alive");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Диплом Врача");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Примените для постоянного улучшения Медсестры\nОткрывает интерфейс лечения после возрождения\nЭффект глобален для всех игроков этого мира\nРаботает только в том случае, если Медсестра жива");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "博士学位证书");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "使用来永久升级你的护士\n重生后打开治疗界面\n该效果作用于本世界所有玩家\n只有在护士活着时起作用");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 500000;
			Item.rare = 5;
			Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 4;
			Item.UseSound = SoundID.Item4;
			Item.consumable = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (AlchemistNPCWorld.foundPHD)
			{
				return false;
			}
			return true;
		}
		
		public override bool? UseItem(Player player)
        {
			AlchemistNPCWorld.foundPHD = true;
			return true;
		}
	}
}
