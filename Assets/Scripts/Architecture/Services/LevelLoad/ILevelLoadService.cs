namespace Architecture.Services.LevelLoad
{
    public interface ILevelLoadService
    {
        void LoadLevel(int index);

        void LoadNextLevel();
        
        void LoadLastLevelFromSave();
    }
}