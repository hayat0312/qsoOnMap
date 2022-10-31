using System;

namespace WindowsFormsApp1
{
    internal class Communication
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string frequency { get; set; }
        public int type { get; set; }
        public string message1 { get; set; }
        public string message2 { get; set; }
        public string message3 { get; set; }
        public string fromCountry { get; set; }
        public string toCountry { get; set; }
        public int childId { get; set; } = 0;
        public bool isFormat { get; set; }
    }
}
