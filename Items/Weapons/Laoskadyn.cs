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
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class Laoskadyn : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laoskadyn");
			Tooltip.SetDefault("Rains exploding homing needles from the sky on swing"
			+"\nNeedles release damaging flames");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Лаоскадин");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сбрасывает взрывающиеся самонаводящиеся иглы с небес\nИглы испускают наносящие урон огни");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "劳斯卡丁");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "挥舞时从天上降下自动追踪敌人的针\n针会释放出有伤害的火焰");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Starfury);
			Item.DamageType = DamageClass.Melee;
			Item.damage = 88;
			Item.width = 78;
			Item.height = 106;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.value = 1000000;
			Item.rare = 11;
            Item.knockBack = 6;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1f;
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = ProjectileType<Projectiles.SharpNeedle>();
			Projectile.NewProjectile(source, position.X+Main.rand.Next(-25,25), position.Y+Main.rand.Next(-25,25), velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
			Projectile.NewProjectile(source, position.X+Main.rand.Next(-50,50), position.Y+Main.rand.Next(-50,50), velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
			return base.Shoot(player, source, position, velocity, type, damage, knockback);
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.TerraBlade)
				.AddIngredient(ItemID.StarWrath)
				.AddIngredient(ItemID.MartianConduitPlating, 50)
				.AddIngredient(ItemID.FragmentSolar, 5)
				.AddIngredient(ItemID.FragmentNebula, 5)
				.AddIngredient(ItemID.FragmentVortex, 5)
				.AddIngredient(ItemID.FragmentStardust, 5)
				.AddIngredient(null, "EmagledFragmentation", 100)
				.AddTile(null, "MateriaTransmutator")
				.Register();
		}
	}
}
