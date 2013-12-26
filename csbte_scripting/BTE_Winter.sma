#include <amxmodx>
#include <fakemeta>
#include <hamsandwich>
#include <bte_api>

new g_bot_init;

public plugin_init()
{
	register_plugin("BTE Winter", "1.0.0", "CSBTE Dev Team");
	
	RegisterHam(Ham_Spawn, "player", "Player_Spawn", 1);
}

public client_putinserver(id)
{ 
	if (is_user_bot(id) && !g_bot_init)
		set_task(1.0, "register_ham_czbots", id);
}

public register_ham_czbots(id)
{
	if (g_bot_init || !is_user_connected(id)) 
		return;

	RegisterHamFromEntity(Ham_Spawn, id, "Player_Spawn", 1);

	g_bot_init = 1;
}

public Player_Spawn(id)
{
	set_pev(id, pev_body, 2);
}