using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System.Linq;
using ReLogic.Content;
using Terraria.GameContent;

namespace AlchemistNPC.Items.Equippable
{
    class CelestialHookItem : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Hook");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "天界钩");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.AmethystHook);
            Item.shootSpeed = 24f;
            Item.rare = 11;
            Item.shoot = ProjectileType<CelestialHookProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LunarHook)
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
				.AddIngredient(null, "EmagledFragmentation", 50)
                .AddTile(null, "MateriaTransmutator")
                .Register();
        }
    }
    class CelestialHookProjectile : ModProjectile
    {
        public static int counter = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Hook");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.GemHookAmethyst);
            Projectile.height = 22;
        }

        public override bool? CanUseGrapple(Player player)
        {
            int hooksOut = 0;
            for (int l = 0; l < 5; l++)
            {
                if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == Projectile.type)
                {
                    hooksOut++;
                }
            }
            if (hooksOut > 4)
            {
                return false;
            }
            return true;
        }

        public override float GrappleRange()
        {
            return 640f;
        }

        public override void NumGrappleHooks(Player player, ref int numHooks)
        {
            numHooks = 4;
        }

        public override void GrappleRetreatSpeed(Player player, ref float speed)
        {
            speed = 24f;
        }

        public override void GrapplePullSpeed(Player player, ref float speed)
        {
            speed = 18;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            counter++;
            Vector2 playerCenter = Main.player[Projectile.owner].MountedCenter;
            Vector2 center = Projectile.Center;
            Vector2 distToProj = playerCenter - Projectile.Center;
            float projRotation = distToProj.ToRotation() - 1.57f;
            float distance = distToProj.Length();
            while (distance > 20f && !float.IsNaN(distance))
            {
                distToProj.Normalize();                 //get unit vector
                distToProj *= 10f;                      //speed = 24
                center += distToProj;                   //update draw position
                distToProj = playerCenter - center;    //update distance
                distance = distToProj.Length();

                Main.EntitySpriteDraw(Mod.Assets.Request<Texture2D>("Items/Equippable/CelestialHookChain").Value, new Vector2(center.X - Main.screenPosition.X, center.Y - Main.screenPosition.Y),
                    new Rectangle(0, 0, TextureAssets.Chain30.Width(), TextureAssets.Chain30.Height()), lightColor, projRotation,
                    new Vector2(TextureAssets.Chain30.Width() * 0.5f, TextureAssets.Chain30.Height() * 0.5f), 1f, SpriteEffects.None, 0);
            }
            return true;
        }
    }
}
