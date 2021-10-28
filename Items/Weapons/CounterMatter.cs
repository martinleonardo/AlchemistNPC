using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class CounterMatter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Counter Matter");
			Tooltip.SetDefault("Globe 199"
			+"\n[c/00FF00:Legendary Weapon]"
			+"\nDestroys nearby enemy projectiles"
			+"\nAfter blocking the projectile, your next strike would be 100% critical"
			+"\n[c/00FF00:Stats are growing through progression]");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Противодействующая Материя");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Шар 199\n[c/00FF00:Легендарное Оружие]\nУничтожает снаряды противника поблизости\nПосле блокирования снаряда ваша следуящая атака гарантированно будет критом\n[c/00FF00:Статы улучшаются по мере прохождения]");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "复位物质");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "球体 199"
			+"\n[c/00FF00:传奇武器]"
			+"\n摧毁附近的敌人抛射物"
			+"\n阻挡抛射物后, 下一次攻击100%暴击"
			+"\n[c/00FF00:属性随进程成长]");
        }
		
		public override void SetDefaults()
		{
			Item.mana = 100;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.value = Item.buyPrice(1, 0, 0, 0);
			Item.rare = 11;
			Item.UseSound = SoundID.Item44;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.buffType = ModContent.BuffType<Buffs.ProjCounter>();
			Item.scale = 0.5f;
		}
		
		public override void UseStyle(Player player, Rectangle rectangle)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 2, true);
			}
		}
	}
}
