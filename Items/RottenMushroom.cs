using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Emperia.Bosses.Mushor;

namespace Emperia.Items
{
    public class RottenMushroom : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rotten Mushroom");
			Tooltip.SetDefault("Ugh, it smells horrible. \n Used in the mushroom biome");
		}
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.maxStack = 999;
            item.rare = 3;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            //return NPC.downedBoss3;
            return player.ZoneGlowshroom;
        }

        public override bool UseItem(Player player)
        {
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType<Mushor>());
            Main.NewText("Fungal spores drift down from above...");
            Main.PlaySound(SoundID.Roar, player.position, 0);
			MyPlayer modPlayer1 = Main.player[Main.myPlayer].GetModPlayer<MyPlayer>();

            return true;
        }
		public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.GlowingMushroom, 10);
				recipe.AddIngredient(ItemID.Bone, 50);
				recipe.AddIngredient(null, "Fungoo", 12);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }
    }
}
