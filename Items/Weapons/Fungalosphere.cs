using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
    public class Fungalosphere : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 120;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 76;
            Item.height = 36;
            Item.useTime = 10;
            Item.useAnimation = 30;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 2;
            Item.UseSound = SoundID.Item34;
            Item.value = 1000000;
            Item.rare = 11;
            Item.autoReuse = true;
            Item.shoot = ProjectileType<Projectiles.FungalosphereProjectile>();
            Item.shootSpeed = 8f;
            Item.useAmmo = AmmoID.Gel;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fungalosphere");
            Tooltip.SetDefault("Consumes gel as ammo"
            + "\nInflicts Electrocute and Frostburn debuffs"
            + "\n33% chance not to consume gel");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "凝胶喷射器");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "消耗凝胶作为弹药\n造成触电和霜火Debuff\n33%的概率不消耗凝胶");
        }

        public override bool CanConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .33;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 4;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(5));
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileType<Projectiles.FungalosphereProjectile>(), damage, knockback, player.whoAmI);
            }
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed1 = velocity.RotatedByRandom(MathHelper.ToRadians(5));
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed1.X, perturbedSpeed1.Y, ProjectileType<Projectiles.FungalosphereProjectileDummy>(), damage, knockback, player.whoAmI);
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ShroomiteBar, 20)
                .AddIngredient(ItemID.SoulofLight, 15)
                .AddIngredient(ItemID.SoulofNight, 15)
                .AddIngredient(ItemID.FragmentSolar, 5)
                .AddIngredient(ItemID.FragmentNebula, 5)
                .AddIngredient(ItemID.FragmentVortex, 5)
                .AddIngredient(ItemID.FragmentStardust, 5)
                .AddIngredient(ItemID.Flamethrower)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
