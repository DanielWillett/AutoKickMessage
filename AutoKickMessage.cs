using Rocket.API.Collections;
using Rocket.Core.Plugins;
using SDG.Unturned;
using Steamworks;

namespace AKM;

public class AutoKickMessage : RocketPlugin<AutoKickMessageConfig>
{
    private readonly TranslationList _defTranslations = new TranslationList()
    {
        new TranslationListEntry("kick_message", "This server is currently offline.")
    };
    public override TranslationList DefaultTranslations => _defTranslations;
    protected override void Load()
    {
        Provider.onCheckValidWithExplanation += OnPreJoin;
        Rocket.Core.Logging.Logger.Log("AutoKickMessage by BlazingFlame#0001 loaded.");
        base.Load();
    }
    protected override void Unload()
    {
        Provider.onCheckValidWithExplanation -= OnPreJoin;
        Rocket.Core.Logging.Logger.Log("AutoKickMessage by BlazingFlame#0001 unloaded.");
        base.Unload();
    }
    private void OnPreJoin(ValidateAuthTicketResponse_t callback, ref bool isValid, ref string explanation)
    {
        ulong id = callback.m_OwnerSteamID.m_SteamID;
        ulong[] pls = this.Configuration.Instance.Whitelist;
        for (int i = 0; i < pls.Length; ++i)
        {
            if (pls[i] == id)
                return;
        }
        isValid = false;
        explanation = Translate("kick_message");
    }
}
