using BepInEx.Configuration;
using Faust.QoLChests.Configs;
using RoR2;

namespace Faust.QoLChests.Hooks;

public static class GeneralHooks
{
    public static void Register(ConfigFile config)
    {
        RoR2Application.onLoad += InteractableStateHandler.Init;
        config.SettingChanged += (sender, args) =>
        {
            InteractableStateHandler.Reset();
        };

        On.RoR2.Highlight.Update += (orig, self) =>
        {
            orig(self);
            if (self.isOn && self.highlightColor == Highlight.HighlightColor.custom)
            {
                self.strength = ModConfig.Instance.HighlightOpacity.Value;
            }
        };
    }
}
