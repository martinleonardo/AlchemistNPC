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
	public class Sasscade : ModItem
	{
		public override void SetDefaults()
		{
		Item.CloneDefaults(3389);
		Item.damage = 125;
		Item.shoot = ProjectileType<Projectiles.SasscadeYoyo>();
		Item.knockBack = 4;
		Item.value = 5000000;
		Item.rare = 11;
		Item.shootSpeed = 12f;
		Item.useTime = 10;
		Item.useAnimation = 10;
		}

		public override void UpdateEquip(Player player)
		{
		player.counterWeight = 556 + Main.rand.Next(6);
        player.yoyoGlove = true;
        player.yoyoString = true;
		}
		
		public override void UpdateInventory(Player player)
		{
		player.counterWeight = 556 + Main.rand.Next(6);
        player.yoyoGlove = true;
        player.yoyoString = true;
		}
		
		public override void HoldItem(Player player)
		{
		player.counterWeight = 556 + Main.rand.Next(6);
        player.yoyoGlove = true;
        player.yoyoString = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sasscade Yo-Yo");
			Tooltip.SetDefault("Legendary Yo-Yo"
			+"\nShoots homing Nebula Blazes to nearby enemies"
			+"\nBlazes destroy enemies with less than 10K HP and inflict heavy damaging debuff"
			+"\nGives effects of Yo-yo Bag while placed in inventory or being held");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сасскад");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Легендарное Йо-йо\nСтреляет самонаводящимися снарядами в ближайших противников\nСнаряды убивают противников, имеющих менее 10К здоровья и накладывают мощный дебафф\nДаёт эффекты сумки Йо-Йо если находится в инвентаре или в руках");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "萨斯卡德");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "传说中的悠悠球\n向附近的敌人发射跟踪的星云火焰\n火焰会秒杀血量少于10K的敌人并且造成重伤Debuff\n握持或放在物品栏里时, 提供悠悠球袋的效果");
        }
	}
}
