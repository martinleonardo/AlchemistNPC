using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class Reverberation : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reverberation (T-04-53)");
			Tooltip.SetDefault("This weapon will no longer be needed if the time comes when everyone's lust is substituted with flowers."
			+ "\n[c/FF0000:EGO weapon]"
			+ "\n50% chance to shot additional tile piercing projectile"
			+ "\nProjectile deals same damage is main, but consumes 15 mana each"
			+ "\nCan be powered up by equipping full 'Reverberation' set");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Реверберация (T-04-53)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Это оружие не будет нужно, если придёт время, когда всеобщая похоть заменится цветами\n[c/FF0000:Оружие Э.П.О.С.]\n50% шанс выстрелить дополнительным снарядом, проходящим сквозь блоки\nУрон этого снаряда будет равен урону основного, но на каждый такой снаряд требуется 15 маны\nМожет быть усилен, если экипировать полный сет 'Реверберация'");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "余香 (T-04-53)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'或许, 当每个人内心的欲望都被花朵取代后, 就不再需要这把武器了吧?'\n[c/FF0000:EGO 武器]\n有50％的几率可以射出额外的子弹\n子弹造成同样的伤害，但是每个需要消耗15点法力\n身着全套'余香'可提升伤害");
        }

		public override void SetDefaults()
		{
			Item.damage = 40;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 8;
			Item.value = 10000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DynastyWood, 200)
				.AddIngredient(ItemID.SoulofLight, 20)
				.AddIngredient(ItemID.SoulofNight, 20)
				.AddIngredient(ItemID.HallowedRepeater)
				.AddTile(null, "WingoftheWorld")
				.Register();
		}

		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).RevSet == true || (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).ParadiseLost == true))
				{
					if (player.statMana >= 30)
					{
					int numberProjectiles = 2 + Main.rand.Next(3);
					for (int i = 0; i < numberProjectiles; i++)
						{
						Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(20));
						Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.CrystalLeafShot, damage/2, knockback, player.whoAmI);
						player.statMana -= 4;
						}
					}
				}
			if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).RevSet == false)
				{
					if (Main.rand.Next(2) == 0 && player.statMana >= 30)
						{
						Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.CrystalLeafShot, damage, knockback, player.whoAmI);
						player.statMana -= 15;
						}
				}
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).ParadiseLost == true)
					{
					Item.damage = 120;
					Item.useTime = 10;
					Item.useAnimation = 10;
					}
					else
					{
					Item.damage = 40;
					Item.useTime = 15;
					Item.useAnimation = 15;
					}
			return base.CanUseItem(player);
		}
	}
}
