namespace AkkaTutorial.IOT.Messages
{
    internal sealed class ReadTemperature
    {
        public static ReadTemperature Instance { get; } = new ReadTemperature();

        private ReadTemperature() { }
    }
}
