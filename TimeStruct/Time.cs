using System.Diagnostics.CodeAnalysis;

namespace TimeStruct
{
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:PrefixLocalCallsWithThis", Justification = "Reviewed.")]
    public struct Time
    {
        private readonly int hours;
        private readonly int minutes;

        public Time(int minutes)
            : this(minutes / 60, minutes % 60)
        {
        }

        public Time(int hours, int minutes)
        {
            // Convert hours and minutes to standard range
            while (minutes < 0)
            {
                hours--;
                minutes += 60;
            }

            while (minutes >= 60)
            {
                hours++;
                minutes -= 60;
            }

            hours %= 24;
            if (hours < 0)
            {
                hours += 24;
            }

            this.hours = hours;
            this.minutes = minutes;
        }

        public int Hours
        {
            get { return hours; }
        }

        public int Minutes
        {
            get { return minutes; }
        }

        public override string ToString()
        {
            return $"{hours:D2}:{minutes:D2}";
        }

        public void Deconstruct(out int hours, out int minutes)
        {
            hours = this.hours;
            minutes = this.minutes;
        }
    }
}
