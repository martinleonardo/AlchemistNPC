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
	public class WorldControlUnit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Simalation Control Unit");
			Tooltip.SetDefault("Exclusive product, designed by Angela"
			+"\nLeft click to change between day and night time"
			+"\nRight click to enable or disable rain (sandstorm in desert)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Устройства контроля симуляции");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Эксклюзивное творение Анджелы\nЛевый клик для смены времени суток\nПравый клик для включения или выключения дождя (песчаной бури в пустыне)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "模拟控制单元");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "独家产品，安吉拉设计\n左键昼夜交换\n右键控制下雨（沙漠中控制沙尘暴）");
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.rare = 5;
			Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 4;
			Item.UseSound = SoundID.Item4;
			Item.consumable = false;
		}
		
		public override bool CanRightClick()
        {            
            return true;
        }

		public override bool ConsumeItem(Player player)
		{
			return false;
		}

        public override void RightClick(Player player)
        {
			Projectile.NewProjectile(player.GetProjectileSource_Item(Item), player.Center, Vector2.Zero, ProjectileType<Projectiles.Sandrain>(), 0, 0, Main.myPlayer);
		}
		
		public override bool? UseItem(Player player)
        {
			if (Main.dayTime)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.NightTimeSet"), 255, 255, 255);
				}
				Main.dayTime = false;
				Main.time = 0.0;
				return true;
			}
			if (!Main.dayTime)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.DayTimeSet"), 255, 255, 255);
				}
				Main.dayTime = true;
				Main.time = 0.0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
