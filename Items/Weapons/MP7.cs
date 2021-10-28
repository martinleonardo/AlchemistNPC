using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Utilities;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class MP7 : ModItem
	{
		public override void SetDefaults()
		{
			Item.useStyle = 5;
			Item.autoReuse = true;
			Item.useAnimation = 2;
			Item.useTime = 2;
			Item.width = 72;
			Item.height = 34;
			Item.shoot = 10;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item11;
			Item.damage = 10;
			Item.shootSpeed = 14f;
			Item.noMelee = true;
			Item.rare = 11;
			Item.knockBack = 3;
			Item.DamageType = DamageClass.Ranged;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MP7");
			Tooltip.SetDefault("[c/00FF00:Ultimate Tinkerer's Reward]"
			+"\nShoots up to 1K bullets per minute"
			+"\n88% chance not to consume ammo");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "MP7");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "[c/00FF00:终极工匠奖励]"
			+"\n每分钟最多发射1K颗子弹"
			+"\n88%概率不消耗弹药");
        }
		
		public override void UpdateInventory(Player player)
		{
			if (!AlchemistNPCWorld.foundMP7)
			{
				AlchemistNPCWorld.foundMP7 = true;
				if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.WorldData);
			}
		}
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return PrefixType<Prefixes.ShiningPrefix>();
		}

		public override bool CanConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .88;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 vector = player.MountedCenter;
			int numberProjectiles = 1 + Main.rand.Next(3); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(3));
				float scale = 1f - (Main.rand.NextFloat() * .4f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(source, vector.X, vector.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}
			return false;
		}
	}
}
