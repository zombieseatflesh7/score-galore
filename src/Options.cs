using Menu.Remix.MixedUI;
using System;
using UnityEngine;

namespace ScoreGalore;

sealed class Options : OptionInterface
{
    public static Configurable<bool> ShowScoreRealTime;
    public static Configurable<float> KillDelay;
    public static Configurable<bool> ShowScoreSleepScreen;
    public static Configurable<bool> ShowAverageSleepScreen;
    public static Configurable<bool> ShowDeathsSleepScreen;
    public static Configurable<bool> ShowScoreMainMenu;
    public static Configurable<bool> ShowDeathsMainMenu;

    public Options()
    {
        ShowScoreRealTime = config.Bind("ScoreGalore_ShowScoreRealTime", true);
        KillDelay = config.Bind("ScoreGalore_KillDelay", 5f, new ConfigAcceptableRange<float>(0, 15f));
        ShowScoreSleepScreen = config.Bind("ScoreGalore_ShowScoreSleepScreen", true);
        ShowAverageSleepScreen = config.Bind("ScoreGalore_ShowAverageSleepScreen", true);
        ShowDeathsSleepScreen = config.Bind("ScoreGalore_ShowDeathsSleepScreen", true);
        ShowScoreMainMenu = config.Bind("ScoreGalore_ShowShowScoreMainMenu", true);
        ShowDeathsMainMenu = config.Bind("ScoreGalore_ShowDeathsMainMenu", true);
    }

    public override void Initialize()
    {
        base.Initialize();

        Tabs = new OpTab[] { new OpTab(this) };

        float y = 420;
        Tabs[0].AddItems(
            new OpLabel(20, 600 - 40, "by Dual", true),
            new OpLabel(20, 600 - 40 - 40, "github.com/Dual-Iron/score-galore"),

            new OpLabel(new(300, y), Vector2.zero, "Show score in real-time", FLabelAlignment.Right),
            new OpCheckBox(ShowScoreRealTime, new(332, y - 4)),

            new OpLabel(new(300, y -= 40), Vector2.zero, "Delay before showing kills, in seconds", FLabelAlignment.Right),
            new OpFloatSlider(KillDelay, new(344, y - 6), 220),

            new OpLabel(new(300, y -= 80), Vector2.zero, "Show score on sleep screen", FLabelAlignment.Right),
            new OpCheckBox(ShowScoreSleepScreen, new(332, y - 4)),

            new OpLabel(new(300, y -= 40), Vector2.zero, "Show average score on sleep screen", FLabelAlignment.Right),
            new OpCheckBox(ShowAverageSleepScreen, new(332, y - 4)),

            new OpLabel(new(300, y -= 40), Vector2.zero, "Show death count on sleep screen", FLabelAlignment.Right),
            new OpCheckBox(ShowDeathsSleepScreen, new(332, y - 4))
            /*
            new OpLabel(new(300, y -= 80), Vector2.zero, "Show score on story menu", FLabelAlignment.Right),
            new OpCheckBox(ShowScoreMainMenu, new(332, y - 4)),

            new OpLabel(new(300, y -= 40), Vector2.zero, "Show death count on story menu", FLabelAlignment.Right),
            new OpCheckBox(ShowDeathsMainMenu, new(332, y - 4))*/
            );
    }
}
