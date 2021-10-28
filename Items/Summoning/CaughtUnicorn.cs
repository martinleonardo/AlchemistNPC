using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Items.Summoning
{
    public class CaughtUnicorn : ModItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Caught Unicorn");
            Tooltip.SetDefault("It is still hostile, better do not release him");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пойманный единорог");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Он всё ещё агрессивен, лучше не выпускайте его");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "被捕获的独角兽");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "仍充满敌意, 最好别释放他");
        }
		
        public override void SetDefaults()
        {
            Item.width = 46;
            Item.height = 42;
            Item.maxStack = 1;
            Item.rare = 10;
            Item.useStyle = 1;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.consumable = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item44;
			Item.makeNPC = NPCID.Unicorn;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 16));
        }
		
		public override void HoldItem(Player player)
		{
		Player.tileRangeX += 600;
        Player.tileRangeY += 600;
		}
		
		public override bool CanUseItem(Player player)
		{
			Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			return (!Collision.SolidCollision(vector2, player.width, player.height));
		}
		
        public override string Texture
		{
			get { return "Terraria/Images/NPC_" + NPCID.Unicorn; }
		}
    }
}