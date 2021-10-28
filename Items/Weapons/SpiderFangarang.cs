using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class SpiderFangarang : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spider Fangarang");
            Tooltip.SetDefault("Throws poisoning boomerang\nCan stack up to 3");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Паучий Клыкоранг");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Бросает отравляющий бумеранг\nМожет складываться до 3");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蛛牙回旋镖");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "投掷涂毒回旋镖\n可以堆叠3个");
        }    
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Bananarang);
			Item.damage = 21;
			Item.DamageType = DamageClass.Throwing;
			Item.rare = 2;
			Item.value = 3333;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.maxStack = 3;
			Item.shoot = ProjectileType<Projectiles.SpiderFangarang>();
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.SpiderFangarang>()] < Item.stack)
			{
				return true;
			}
			return false;
		}
	}
}