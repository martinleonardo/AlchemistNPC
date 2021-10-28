using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class DivineWaspnade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Divine Lava Waspnade");
			Tooltip.SetDefault("Releases friendly Wasps after explosion"
			+"\nWasps are inflicting On Fire! and Ichor debuffs"
			+"\nEmpowered with Hive Pack/Plague Hive equipped");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Осаната из Вечной Лавы");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выпускает дружественных ос после взрыва\nОсы накладывают Ихор и поджигают противников\nМогут быть усилены экипировкой Пчелиного Рюкзака/Чумного Улья");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "神圣熔岩黄蜂雷");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "爆炸后释放友善黄蜂"
			+"\n黄蜂造成着火和脓液Debuff"
			+"\n装备蜂窝背包/瘟疫蜂巢(灾厄)时威力增强");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Beenade);
			Item.DamageType = DamageClass.Throwing;
			Item.damage = 25;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.value = 10000;
			Item.rare = 8;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<Projectiles.DivineWaspnade>();
			Item.shootSpeed = 8f;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe(25)
				.AddIngredient(null, "Waspnade", 25)
				.AddIngredient(null, "DivineLava")
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
