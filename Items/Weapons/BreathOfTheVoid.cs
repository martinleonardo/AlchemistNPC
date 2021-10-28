using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class BreathOfTheVoid : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 22222;
			Item.DamageType = DamageClass.Magic;
			Item.width = 38;
			Item.height = 34;
			Item.useTime = 5;
			Item.useAnimation = 15;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.UseSound = SoundID.Item34;
			Item.value = 10000000;
			Item.rare = 11;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<Projectiles.BreathOfTheVoid>();
			Item.shootSpeed = 9f;
			Item.channel = true;
			Item.noUseGraphic = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Expiration");
			Tooltip.SetDefault("Feel the Breath of the Void");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "限度之息");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "感受虚空的气息");
        }
	}
}
