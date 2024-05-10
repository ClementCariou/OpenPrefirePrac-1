namespace OpenPrefirePrac;

public class DefaultConfig
{
    public int Difficulty { get; set; } = 3;

    public int TrainingMode { get; set; } = 0;

    public int BotWeapon {get; set; } = 0;

    public bool ChainPractices { get; set; } = false;

    public List<string> MapOrder { get; set; } = new();

    public DefaultConfig(int difficulty, int trainingMode, int botWeapon, bool chainPractices, List<string> mapOrder)
    {
        Difficulty = difficulty;
        TrainingMode = trainingMode;
        BotWeapon = botWeapon;
        ChainPractices = chainPractices;
        MapOrder = mapOrder;
    }
}