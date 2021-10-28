using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class Nyx : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nyx");
			Tooltip.SetDefault("Basically, it is just a Gauss Gun"
			+ "\nPierces through multiple enemies"
			+ "\nHas 2 modes:"
			+ "\nSlowmode on left click (1 shot per second)"
			+ "\nFastmode on right click (2 shots per second, damage is reduced)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Никс");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Всего лишь пушка Гаусса.\nПробивает значительное количество противников одним выстрелом\nИмеет два режима стрельбы:\nМедленный (левая кнопка мыши) - производит один выстрел.\nБыстрый (правая кнопка мыши) - производит два выстрела с пониженным уроном.");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "尼克斯");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "基本上, 它只是个高斯炮\n能穿透多个敌人\n有两种发射方式:\n左键慢速发射 (1发/秒)\n右键快速发射 (2发/秒, 伤害降低)");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.SniperRifle);
			Item.damage = 750;
			Item.autoReuse = true;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item36;
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = ProjectileType<Projectiles.Nyx>();
			return true;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useTime = 30;
				Item.useAnimation = 30;
				Item.damage = 425;
			}
			else
			{
				Item.useTime = 60;
				Item.useAnimation = 60;
				Item.damage = 750;
			}
			return base.CanUseItem(player);
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SniperRifle)
				.AddIngredient(ItemID.Ectoplasm, 50)
				.AddIngredient(ItemID.ShroomiteBar, 8)
				.AddIngredient(ItemID.LunarBar, 8)
				.AddIngredient(null, "NyctosythiaCrystal", 10)
				.AddTile(null, "MateriaTransmutator")
				.Register();
		}
	}
}