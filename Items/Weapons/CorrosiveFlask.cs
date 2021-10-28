using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class CorrosiveFlask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrosive Flask");
			Tooltip.SetDefault("Toxic Flask, improved by Celestial Powers.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Колба Коррозии");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Колба с токсинами, улучшенная Небесными Силами");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "腐蚀烧瓶");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "被炼金师加强过的剧毒药水");
        }    
		public override void SetDefaults()
		{
			Item.damage = 175;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 20;
			Item.width = 28;
			Item.height = 28;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.knockBack = 10;
			Item.value = 100000;
			Item.rare = 9;
			Item.UseSound = SoundID.Item106;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<Projectiles.CorrosiveFlaskMagic>();
			Item.shootSpeed = 16f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.ToxicFlask, 1)
				.AddIngredient(ItemID.FragmentSolar, 5)
				.AddIngredient(ItemID.FragmentNebula, 5)
				.AddIngredient(ItemID.FragmentVortex, 5)
				.AddIngredient(ItemID.FragmentStardust, 5)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}