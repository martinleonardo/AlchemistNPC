using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;
using Terraria.Utilities;

namespace AlchemistNPC.Items.Weapons
{
	public class Hive : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hive");
			Tooltip.SetDefault("''NOT THE BEES!''"
			+"\nShoots beehive, which is spreading bees around it"
			+"\nBreaks on collide, releasing even more bees"
			+"\nBoosted stats will be shown after the first use");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Улей");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''ТОЛЬКО НЕ ПЧЁЛЫ!''\nВыстреливает ульем, испускающим пчёл вокруг\nЛомается при столкновении, выпуская ещё больше пчёл");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蜂巢");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''NOT THE BEES!''"
			+"\n发射蜂巢, 在周围传播蜜蜂"
			+"\n碰撞时破坏, 释放更多蜜蜂"
			+"\n提升过后的属性将会在使用后显示");
			Item.staff[Item.type] = true;
        }

		public override void SetDefaults()
		{
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.damage = 52;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 15;
			Item.rare = 11;
			Item.width = 40;
			Item.height = 40;
			Item.UseSound = SoundID.Item20;
			Item.useStyle = 5;
			Item.shootSpeed = 11f; 
			Item.knockBack = 4;
			Item.value = Item.sellPrice(1, 0, 0, 0);
			Item.autoReuse = true;
			Item.shoot = ProjectileType<Projectiles.Hive>();
		}
	}
}
