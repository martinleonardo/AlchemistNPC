using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Items.Weapons
{
	public class RecluseFang : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Recluse's Fang");
            Tooltip.SetDefault("Throws venomous boomerang");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Клык Реклюзы");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Бросает ядовитый бумеранг");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "黑隐士牙旋刃");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "投掷剧毒回旋刃");
        }   
		
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Bananarang);
			Item.damage = 48;
			Item.DamageType = DamageClass.Throwing;
			Item.maxStack = 1;
			Item.rare = 2;
			Item.value = 3333;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.shootSpeed = 16f;
			Item.shoot = ProjectileType<Projectiles.RecluseFang>();
		}
		
		public override void AddRecipes()
        {
            CreateRecipe()
            	.AddIngredient(ItemID.SpiderFang, 12)
            	.AddIngredient(ModContent.ItemType<Items.Weapons.SpiderFangarang>(), 3)
				.AddTile(TileID.Anvils)
            	.Register();
        }
	}
}