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
	public class LaserCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser Cannon");
			Tooltip.SetDefault("Shoots homing exploding energy balls"
			+ "\nDoes not require ammo");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Лазерная Пушка");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выстреливает самонаводящиеся взрывающиеся энергетические шары\nНе требует патронов");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "激光炮");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "发射追踪的爆炸能量球"
			+"\n不消耗弹药");
        }

		public override void SetDefaults()
		{
			Item.damage = 333;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 44;
			Item.height = 38;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 6;
			Item.value = 1000000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item92;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<Projectiles.LaserCannon>(); //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 16f;
		}
	}
}
