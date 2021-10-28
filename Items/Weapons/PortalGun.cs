using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class PortalGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rick's Portal Gun");
			Tooltip.SetDefault("Copy of Rick Sanchez's Portal Gun"
			+"\nOpens portals to the random dangerous dimensions"
			+"\nRequires Energy Capsules as ammo"
			+"\nHope this thing wouldn't cause appearence of SEAL team Ricks");
			
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Портальная пушка Рика");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Копия портальной пушки Рика Санчеза\nОткрывает порталы в различные измерения\nТребует Капсулы с энергией в качестве патронов\nНадеюсь, что она не вызовет появление Рик спецназа");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "瑞克的传送枪");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "瑞克·桑切斯的传送枪的复制品"
			+"\n打开通往随机危险维度的传送门"
			+"\n需要能量胶囊作为弹药"
			+"\n希望这玩意别引来瑞克海豹突击队");
		}

		public override void SetDefaults()
		{
			Item.damage = 75;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = 1000000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item114;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<Projectiles.PortalGunProj>();
			Item.shootSpeed = 16f;
			Item.useAmmo = ModContent.ItemType<Items.Weapons.EnergyCapsule>();
		}
	}
}
