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
    public class ChaingunMeatGrinder : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chain Gun ''Meat Grinder''");
            Tooltip.SetDefault("Forged by technologies of ancient colonizers."
            + "\nHas 6 rotating barrels with 17mm caliber"
            + "\nGains shooting speed over time"
            + "\nUses special ammo (17mm rounds)"
            + "\n66% chance not to consume ammo");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пулемёт ''Мясорубка''");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Изготовлен по технологии древних колонизаторов\nОружие имеет шесть вращающихся стволов калибра 17мм\nСкорость стрельбы постепенно возрастает\nИспользует специальные патроны (17mm патрон)\n66% шанс не потратить патроны");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "机关炮 ''绞肉机''");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "用古代殖民者的科技打造."
            + "\n拥有6个17mm口径的旋转枪管"
            + "\n随时间增加射速"
            + "\n使用特殊子弹 (17mm 子弹)"
            + "\n66%概率不消耗弹药");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ChainGun);
            Item.damage = 40;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 3;
            Item.width = 50;
            Item.height = 30;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.noMelee = true;
            Item.value = 1000000;
            Item.rare = 11;
            Item.autoReuse = true;
            Item.shoot = 638;
            Item.useAmmo = ModContent.ItemType<Items.Weapons.MGB>();
        }

        public override void UseStyle(Player player, Rectangle rectangle)
        {
            ((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).MeatGrinderOnUse = true;
            Item.useTime = 10;
            Item.useAnimation = 10;
            ((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).MeatGrinderUsetime++;
            if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).MeatGrinderUsetime >= 240)
            {
                Item.useTime = 3;
                Item.useAnimation = 3;
            }
            else if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).MeatGrinderUsetime >= 180)
            {
                Item.useTime = 5;
                Item.useAnimation = 5;
            }
            else if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).MeatGrinderUsetime >= 90)
            {
                Item.useTime = 8;
                Item.useAnimation = 8;
            }
        }

        public override void HoldItem(Player player)
        {
            if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).MeatGrinderOnUse == false)
            {
                ((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).MeatGrinderUsetime = 0;
            }
        }

        public override bool CanConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .66;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(3));
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            velocity.X = perturbedSpeed.X;
            velocity.Y = perturbedSpeed.Y;
            Vector2 perturbedSpeed2 = velocity.RotatedByRandom(MathHelper.ToRadians(3));
            Vector2 perturbedSpeed3 = velocity.RotatedByRandom(MathHelper.ToRadians(3));
            float speedX2 = perturbedSpeed2.X;
            float speedY2 = perturbedSpeed2.Y;
            float speedX3 = perturbedSpeed3.X;
            float speedY3 = perturbedSpeed3.Y;
            Projectile.NewProjectile(source, vector.X, vector.Y + 4, speedX2, speedY2, 638, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(source, vector.X, vector.Y, velocity.X, velocity.Y, 638, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(source, vector.X, vector.Y - 4, speedX3, speedY3, 638, damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ChainGun)
                .AddIngredient(ItemID.ShroomiteBar, 20)
                .AddRecipeGroup("AlchemistNPC:Tier3Bar", 20)
                .AddIngredient(null, "AlchemicalBundle")
                .AddIngredient(null, "EmagledFragmentation", 150)
                .AddTile(null, "MateriaTransmutator")
                .Register();
        }
    }
}
