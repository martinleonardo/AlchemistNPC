using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ChromovariaBulletInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chromovaria Bullet");
			Tooltip.SetDefault("Creates heavy damaging light explosion and inflicts Daybroken debuff"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Хромовариевая пуля (Бесконечная)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Создаёт взрыв, наносящий значительные повреждения и накладывает мощный дебафф\nБесконечна");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "炫彩弹 (无限)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "造成巨大的伤害性爆炸并给予破晓Debuff\n无限");
        }    
		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 1, 0);
			Item.rare = 10;
			Item.shoot = ProjectileType<Projectiles.ChromovariaBullet>();
			Item.shootSpeed = 16f; 
			Item.ammo = AmmoID.Bullet; //
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "ChromovariaBullet", 3996)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}
