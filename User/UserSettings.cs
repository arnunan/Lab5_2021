namespace User
{
    public static class UserSettings
    {
        private static int _musicVolume = 50;
        public static int MusicVolume
        {
            get => _musicVolume;
            set
            {
                if (value < 0 || value > 100)
                    return;
                _musicVolume = value;
            }
        }

        public static SaveFile File { get; set; }
        public static Map Map() => new Map(File.MapInfo);
    }
}
