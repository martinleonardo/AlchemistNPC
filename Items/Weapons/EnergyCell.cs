using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class EnergyCell : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Requred to shoot from Quantum Destabilizer");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Энергоячейка");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Необходима для стрельбы из Квантового Дестабилизатора");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "能源电池");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "用于量子干扰器的能源");
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
			Item.value = Item.sellPrice(0, 0, 75, 0);
			Item.rare = 10;
			Item.shoot = ProjectileType<Projectiles.QuantumDestabilizer>();
			Item.ammo = Item.type; // The first item in an ammo class sets the AmmoID to it's type
		}
	}
}
