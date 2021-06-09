namespace User
{
    public static class SystemFiles
    {
        public const string PropertiesFolder = "../../Properties/";
        public const string SpritesFolder = PropertiesFolder + "Sprites/";
        public const string SaveFilesFolder = "../../Save/";
        public const string EventsFilesFolder = "../../Events/";

        public const string PlayerSprite = SpritesFolder + "tiles/Player.png";

        public const string WelcomeCaption = "Introduction";
        public const string WelcomeText =
            @"Тебе нужно как можно дольше выживать и собирать ресурсы.
Для движения используй WASD. Когда ты встанешь на клетку с обломками — Серая клетка с белыми пикселями — нажми Е, чтобы собрать ресурсы.
При движении вне корабля у тебя будет уменьшаться количество еды, внутри корабля ты можешь двигаться без ограничений.
Корабль — скопление серых клеток в центре карты.
Используя терминал справа, ты можешь покупать и продавать ресурсы.
Чтобы купить или продать, нужно ввести в поле ниже ключ вида N-m, где N — буква, а m — число.";
    }
}
