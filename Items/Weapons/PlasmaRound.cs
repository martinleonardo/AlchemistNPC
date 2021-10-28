using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class PlasmaRound : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plasma Round");
			Tooltip.SetDefault("Contains raw energy inside"
			+"\nRequired for using Tritantrum");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Плазменный заряд");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Содержит чистую энергию внутри\nНеобходима для использования Тритантрума");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "等离子体");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "里面包含原始能量\n是三项之怒的弹药");
        }
		
		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 5, 0);
			Item.rare = 10;
			Item.shoot = ProjectileType<Projectiles.PlasmaRound>();
			Item.shootSpeed = 32f; 
			Item.ammo = Item.type; //
		}
	}
}
