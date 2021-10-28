using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class Tritantrum : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tritantrum");
			Tooltip.SetDefault("Shoots exploding plasma balls"
			+ "\nRequires special ammo (Plasma Round)"
			+ "\n50% chance not to consume ammo");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Тритантрум");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выстреливает взрывающиеся плазменные шары\nТребует особые патроны для стрельбы (Плазменный заряд)\n50% шанс не потратить патроны");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "三项之怒");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "发射会爆炸的等离子体\n需要特殊弹药 (等离子体)\n50%的几率不消耗弹药");
        }

		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 92;
			Item.height = 40;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 8;
			Item.value = 1000000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 64f;
			Item.useAmmo = ModContent.ItemType<Items.Weapons.PlasmaRound>();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		
		public override bool CanConsumeAmmo(Player player)
		{
		return Main.rand.NextFloat() >= .5;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.LunarBar, 15)
				.AddIngredient(ItemID.SoulofLight, 30)
				.AddIngredient(ItemID.FragmentSolar, 5)
				.AddIngredient(ItemID.FragmentNebula, 5)
				.AddIngredient(ItemID.FragmentVortex, 5)
				.AddIngredient(ItemID.FragmentStardust, 5)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}

		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, position.X+Main.rand.Next(-10,10), position.Y+3+Main.rand.Next(-3,3), velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
			Projectile.NewProjectile(source, position.X+Main.rand.Next(-10,10), position.Y-3+Main.rand.Next(-3,3), velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
			return false;
		}
	}
}
