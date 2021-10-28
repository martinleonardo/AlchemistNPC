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
    public class UnchainedAkumu : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unchained ''Akumu''");
            Tooltip.SetDefault("It means ''[c/FF00FF:nightmare]'' in Japanese"
            + "\nIts slice pierces through any amount of enemies on its way"
            + "\nLeft click launches a short travelling projectile"
            + "\nRight click slices the air in place"
            + "\nWhile at 35% HP or lower, Akumu generates projectile reflecting shield"
            + "\nWhile above 35% HP, Akumu releases flying minion");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Освобождённая ''Акуму''");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Это означает ''кошмар'' на Японском\nЕё удар пронзает любое количество врагов\nЗапускает снаряд по нажатию левой кнопки мыши\nРазрезает воздух на месте по нажатию правой кнопки мыши\nПри здоровье ниже 35% призывает отражающий снаряды щит\nПри здоровье выше 35% создаёт летающего прислужника");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "解封 ''Akumu''");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "在日语里, 'Akumu'的意思是'噩梦'"
            + "\n它的斩击能穿透经过的所有敌人"
            + "\n左键发射剑气"
            + "\n右键近距离攻击"
            + "\n生命值低于35%时, Akumu会生成反射抛射物的护盾"
            + "\n高于35%时, Akumu会释放飞行的奴仆");
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.damage = 250;
            Item.width = 58;
            Item.height = 50;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = 1;
            Item.value = 10000000;
            Item.rare = 11;
            Item.knockBack = 8;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ProjectileType<Projectiles.Akumu>();
            Item.shootSpeed = 8f;
        }

        public override void HoldItem(Player player)
        {
            if (player.statLife > player.statLifeMax2 * 0.35f)
            {
                player.AddBuff(ModContent.BuffType<Buffs.TrueAkumuAttack>(), 2);
            }
            if (player.statLife < player.statLifeMax2 * 0.35f)
            {
                ((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).Akumu = true;
                player.AddBuff(ModContent.BuffType<Buffs.TrueAkumu>(), 2);
            }
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
            }
            else
            {
                Item.useTime = 25;
                Item.useAnimation = 25;
            }
            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse != 2)
            {
                Item.noMelee = false;
                Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileType<Projectiles.AkumuThrow>(), damage, knockback, player.whoAmI);
            }
            if (player.altFunctionUse == 2)
            {
                Item.noMelee = true;
                if (player.direction == 1)
                {
                    Vector2 vel = new Vector2(0, 0);
                    vel *= 0f;
                    Projectile.NewProjectile(source, position.X, position.Y, vel.X, vel.Y, ProjectileType<Projectiles.Akumu>(), damage, knockback, player.whoAmI);
                }
                if (player.direction == -1)
                {
                    Vector2 vel = new Vector2(-1, 0);
                    vel *= 0f;
                    Projectile.NewProjectile(source, position.X, position.Y, vel.X, vel.Y, ProjectileType<Projectiles.AkumuMirror>(), damage, knockback, player.whoAmI);
                }
            }
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(null, "Akumu")
                .AddIngredient(null, "ChromaticCrystal", 5)
                .AddIngredient(null, "SunkroveraCrystal", 5)
                .AddIngredient(null, "NyctosythiaCrystal", 5)
				// IMPLEMENT WHEN WEAKREFERENCES FIXED
				/*
				if (ModLoader.GetMod("CalamityMod") != null)
				{
						.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 10)
						.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 15)

				}
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
						.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 5)
						.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 5)
						.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 5)
				}
				*/
				.AddIngredient(null, "EmagledFragmentation", 150)
                .AddTile(null, "MateriaTransmutator")
                .Register();
        }
    }
}
