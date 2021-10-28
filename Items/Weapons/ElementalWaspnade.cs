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
	public class ElementalWaspnade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Waspnade");
			Tooltip.SetDefault("Releases friendly Wasps after explosion"
			+"\nWasps inflicting Corrosion, Cursed Flames and Ichor debuffs"
			+"\nEmpowered with Hive Pack/Plague Hive equipped");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Элементальная Осаната");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выпускает дружественных ос после взрыва\nОсы накладывают Коррозию, Проклятое Пламя и Ихор\nМогут быть усилены экипировкой Пчелиного Рюкзака/Чумного Улья");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "元素黄蜂雷");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "爆炸后释放友善黄蜂"
			+"\n黄蜂造成腐蚀, 咒火和脓液Debuff"
			+"\n装备蜂窝背包/瘟疫蜂巢(灾厄)时威力增强");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Beenade);
			Item.DamageType = DamageClass.Throwing;
			Item.damage = 50;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.value = 10000;
			Item.rare = 10;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<Projectiles.ElementalWaspnade>();
			Item.shootSpeed = 8f;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe(50)
				.AddIngredient(null, "DivineWaspnade", 25)
				.AddIngredient(null, "CursedWaspnade", 25)
				.AddIngredient(ItemID.FragmentSolar)
				.AddIngredient(ItemID.FragmentNebula)
				.AddIngredient(ItemID.FragmentVortex)
				.AddIngredient(ItemID.FragmentStardust)
				.AddTile(null, "MateriaTransmutator")
				.Register();
		}
	}
}
