using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons.Mushor {
public class MycelialShield : ModItem
{
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mycelial Shield");
		}
	public override void SetDefaults()
	{
		item.width = 38;
		item.height = 44;
		item.value = 50000;
		item.expert = true;
		item.defense = 5;
		item.accessory = true;
	}
	
	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
		modPlayer.sporeFriend = true;
		player.lifeRegen += 2;
		
	}

}}