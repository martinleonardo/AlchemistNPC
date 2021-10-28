using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class EnergyCapsule : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Energy Capsule");
			Tooltip.SetDefault("Requred to shoot from Portal Gun");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Капсула с энергией");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Необходима для стрельбы из Портальной Пушки");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "能量胶囊");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "传送枪射击所需");
        }

		public override void SetDefaults()
		{
			Item.damage = 1;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 22;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(0, 0, 20, 0);
			Item.rare = 10;
			Item.shoot = ProjectileType<Projectiles.PortalGunProj>();
			Item.ammo = Item.type;
		}
	}
}
