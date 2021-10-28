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
	public class CursedWaspnade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Ice Waspnade");
			Tooltip.SetDefault("Releases friendly Wasps after explosion"
			+"\nWasps are inflicting Frostburn and Cursed Flame debuffs"
			+"\nEmpowered with Hive Pack/Plague Hive equipped");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Осаната из Проклятого Льда");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выпускает дружественных ос после взрыва\nОсы накладывают Морозный Ожог и поджигают Проклятым Пламенем\nМогут быть усилены экипировкой Пчелиного Рюкзака/Чумного Улья");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "诅咒冰蜂");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "爆炸后释放友好黄蜂"
			+"\n黄蜂造成霜火和咒火Debuff"
			+"\n装备蜂窝背包/瘟疫蜂巢(灾厄)时威力增强");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Beenade);
			Item.DamageType = DamageClass.Throwing;
			Item.damage = 30;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.value = 10000;
			Item.rare = 8;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<Projectiles.CursedWaspnade>();
			Item.shootSpeed = 8f;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe(25)
				.AddIngredient(null, "Waspnade", 25)
				.AddIngredient(null, "CursedIce")
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
