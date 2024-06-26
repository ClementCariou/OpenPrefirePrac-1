using System.Text.Json;

namespace OpenPrefirePrac;

public class DefaultConfig
{
    public int Difficulty { get; set; } = 3;

    public int TrainingMode { get; set; } = 0;

    public int BotWeapon {get; set; } = 0;

    public bool BotAimLock {get; set; } = true;

    public bool ChainPractices { get; set; } = false;

    public List<string> MapOrder { get; set; } = new();

    private string _moduleDirectory = "";

    // public DefaultConfig(int difficulty, int trainingMode, int botWeapon)
    // {
    //     Difficulty = difficulty;
    //     TrainingMode = trainingMode;
    //     BotWeapon = botWeapon;
    // }

    public DefaultConfig()
    {
        // DeserializeConstructor
    }

    public DefaultConfig(string moduleDirectory)
    {
        _moduleDirectory = moduleDirectory;
    }
    
    public void LoadDefaultSettings()
    {
        string path = $"{_moduleDirectory}/default_cfg.json";

        // Read default settings from PlayerStatus.cs
        // PlayerStatus tmpStatus = new PlayerStatus();
        // int tmpDifficulty = tmpStatus.HealingMethod;
        // int tmpTrainingMode = tmpStatus.TrainingMode;
        // int tmpBotWeapon = tmpStatus.BotWeapon;

        if (!File.Exists(path))
        {
            // Use default settings
            Console.WriteLine("[OpenPrefirePrac] No custom settings provided. Will use default settings.");
        }
        else
        {
            // Load settings from default_cfg.json
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true,

            };

            string jsonString = File.ReadAllText(path);
            
            try
            {
                DefaultConfig jsonConfig = JsonSerializer.Deserialize<DefaultConfig>(jsonString, options)!;

                if (jsonConfig.Difficulty > -1 && jsonConfig.Difficulty < 5)
                {
                    Difficulty = jsonConfig.Difficulty;
                }

                if (jsonConfig.TrainingMode > -1 && jsonConfig.TrainingMode < 2)
                {
                    TrainingMode = jsonConfig.TrainingMode;
                }
                
                if (jsonConfig.BotWeapon > -1 && jsonConfig.BotWeapon < 5)
                {
                    BotWeapon = jsonConfig.BotWeapon;
                }

                if (jsonConfig.ChainPractices)
                {
                    ChainPractices = jsonConfig.ChainPractices;
                    MapOrder = jsonConfig.MapOrder;
                }

                BotAimLock = jsonConfig.BotAimLock;

                Console.WriteLine($"[OpenPrefirePrac] Using default settings: Difficulty = {Difficulty}, TrainingMode = {TrainingMode}, BotWeapon = {BotWeapon}, BotAimLock = {BotAimLock}");
            }
            catch (System.Exception)
            {
                Console.WriteLine("[OpenPrefirePrac] Failed to load custom settings. Will use default settings.");
            }
        }

        // _defaultPlayerSettings = new DefaultConfig(tmpDifficulty, tmpTrainingMode, tmpBotWeapon);
    }
}