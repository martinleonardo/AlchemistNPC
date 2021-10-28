using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ChaosBomb : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 11111;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 26;
			Item.noUseGraphic = true;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = ProjectileType<Projectiles.ChaosBomb>();
			Item.shootSpeed = 16f;
			Item.useStyle = 1;
			Item.knockBack = 8;
			Item.value = 1000000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaos Bomb");
			Tooltip.SetDefault("CHAOS! CHAOS!"
			+"\nExplodes on contact, releasing random chaos");
			
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Хаотическая Бомба");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "ХАОС! ХАОС!\nВзрывается при касании, производя случайный хаос");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "混沌爆弹");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "混·沌! 混·沌!"
			+"\n接触时爆炸, 释放随机混沌");
        }
	}
}
