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
	public class UgandanTotem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ugandan Totem");
			Tooltip.SetDefault("Summons Ugandan Warrior to protect you"
			+"\nMore than 1 cannot be summoned"
			+"\nMax minions slots multiply summon's damage");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Тотем Уганды");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Призывает Воина Уганды для уничтожения ваших врагов\nНельзя призвать более одного\nМаксимальное количество прислужников увеличивает урон");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "乌干达图腾");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "召唤乌干达战士保护你"
			+"\n最多召唤1个"
			+"\n召唤物伤害与最大召唤栏数量成正比");
        }
		
		public override void SetDefaults()
		{
			Item.damage = 12345;
			Item.mana = 200;
			Item.width = 28;
			Item.height = 22;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.knockBack = 8;
			Item.value = Item.buyPrice(15, 0, 0, 0);
			Item.rare = 11;
			Item.UseSound = SoundID.Item44;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.shoot = ProjectileType<Projectiles.Minions.UgandanWarrior>();
			Item.shootSpeed = 16f;
			Item.buffType = ModContent.BuffType<Buffs.UgandanWarrior>();
			Item.DamageType = DamageClass.Summon;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override void UseStyle(Player player, Rectangle rectangle)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == Item.useTime)
			{
				player.AddBuff(Item.buffType, 3600, true);
			}
		}
		
		public override bool? UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim(false);
			}
			return base.UseItem(player);
		}

		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.AddBuff(Item.buffType, 2);

			for (int l = 0; l < Main.projectile.Length; l++)
			{
				Projectile proj = Main.projectile[l];
				if (proj.active && proj.type == Item.shoot && proj.owner == player.whoAmI)
				{
					proj.active = false;
				}
			}
			
			Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;

			var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
			projectile.originalDamage = Item.damage;
			return false;
		}
	}
}
