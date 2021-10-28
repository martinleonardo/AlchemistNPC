using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class BlackWidowGreatbow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Black Widow Greatbow");
			Tooltip.SetDefault("Shoots 3 highly damaging spider fangs"
			+"\nNormal enemies would be impaled and immobilized");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Большой лук Чёрной Вдовы");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выстреливает 3 прибивающих противников паучий клыка\nМожет обездвижить обычных противников");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "黑寡妇巨弓");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "发射3发高伤害蜘蛛毒牙\n正常敌人会被刺穿并被束缚");
        }

		public override void SetDefaults()
		{
			Item.damage = 140;
			Item.DamageType = DamageClass.Ranged;
			Item.crit = 21;
			Item.width = 32;
			Item.height = 46;
			Item.useTime = 75;
			Item.useAnimation = 75;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 8;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.useAmmo = AmmoID.Arrow;
			Item.shootSpeed = 12f;
		}

		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = ProjectileType<Projectiles.SpiderFang>();
			float num121 = 0.314159274f;
			int num122 = 3;
			Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
			float num82 = Main.mouseX + Main.screenPosition.X - vector2.X;
			float num83 = Main.mouseY + Main.screenPosition.Y - vector2.Y;
			Vector2 vector14 = new Vector2(velocity.X, velocity.Y);
			vector14.Normalize();
			vector14 *= 40f;
			bool flag11 = Collision.CanHit(vector2, 0, 0, vector2 + vector14, 0, 0);
			int arrowtype = type;
			for (int num123 = 0; num123 < num122; num123++)
			{
				float num124 = num123 - (num122 - 1f) / 2f;
				Vector2 vector15 = vector14.RotatedBy(num121 * num124, default);
				if (!flag11)
				{
					vector15 -= vector14;
				}
				if (Main.rand.NextBool(8))
				{
					//Reimplement
					//type = ProjectileType<Projectiles.OceanicArrow>();
					type = arrowtype;
				}
				else
				{
					type = arrowtype;
				}
				int num125 = Projectile.NewProjectile(source, vector2.X + vector15.X, vector2.Y + vector15.Y, num82, num83, type, damage, knockback, player.whoAmI);
				Main.projectile[num125].noDropItem = true;
			}
			return false;
		}
		
		public override void AddRecipes()
        {
            CreateRecipe()
            	.AddIngredient(ItemID.SpiderFang, 12)
            	.AddIngredient(ModContent.ItemType<Items.Weapons.FangBallista>())
				.AddTile(TileID.Anvils)
            	.Register();
        }
	}
}