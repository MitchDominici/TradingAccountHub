using System.Collections.Generic;

namespace AlpacaAccountHub.Data.SymbolData
{
    public class TickerDetails
    {
        public string ticker { get; set; }
        public string name { get; set; }

        public string primaryExhange { get; set; }

        public bool active { get; set; }

        public string currency { get; set; }

        public string url { get; set; }

        public double lastTradePrice { get; set; } //lastTrade Price from Snapshot - Gainers / Losers

        public long lastTrade_Shares { get; set; }

        public double todaysVolume { get; set; }

        public double previousDayVolume { get; set; }

        public double previousDayClose { get; set; }

        public double minuteClose { get; set; }

        public double todaysChange { get; set; }

        public double todaysChangePerc { get; set; }

        public double previousDayHigh { get; set; }

        public double todaysOpen { get; set; }


    }

    public class Symbols
    {
        public List<TickerDetails> tickerDetails { get; set; }

    }

    public class StreamMessage
    {
        public string message { get; set; }
    }

    public class Day
    {
        public double c { get; set; }
        public double h { get; set; }
        public double l { get; set; }
        public double o { get; set; }
        public int v { get; set; }
        public double vw { get; set; }
    }

    public class LastQuote
    {
        public double P { get; set; }
        public int S { get; set; }
        public double p { get; set; }
        public int s { get; set; }
        public long t { get; set; }
    }

    public class LastTrade
    {
        public object c { get; set; }
        public string i { get; set; }
        public double p { get; set; }
        public int s { get; set; }
        public long t { get; set; }
        public int x { get; set; }
    }

    public class Min
    {
        public double c { get; set; }
        public double h { get; set; }
        public double l { get; set; }
        public double o { get; set; }
        public int v { get; set; }
        public double vw { get; set; }
    }

    public class PrevDay
    {
        public double c { get; set; }
        public double h { get; set; }
        public double l { get; set; }
        public double o { get; set; }
        public int v { get; set; }
        public double vw { get; set; }
    }

    public class RootObject
    {
        public Day day { get; set; }
        public LastQuote lastQuote { get; set; }
        public LastTrade lastTrade { get; set; }
        public Min min { get; set; }
        public PrevDay prevDay { get; set; }
        public string ticker { get; set; }
        public double todaysChange { get; set; }
        public double todaysChangePerc { get; set; }
        public long updated { get; set; }
    }


}
