namespace Orderly.Models.Enums
{
    public enum RequestStatus
    {
        NOTOK = 0,
        OK = 1
    }
    public enum PortfolioMonitoringTypes
    {
        Etherum = 1,
        BitCoin = 2,
        EthPlorer = 3
    }
    public enum DistributionTypes
    {
        Monthly = 1,
        Linear = 2,
        Quarterly = 3,
        BiAnnual = 4,
        Annual = 5,
        Dynamic = 6
    }
    public enum InvestmentTypes
    {
        Individual = 1,
        Group = 2
    }
    
    public enum CalendarTypes
    {
        All = 1,
        OnGoing = 2,
        UpComming = 3
    }

    /// <summary>
    /// Notification type
    /// </summary>
    public enum NotifyType
    {
        /// <summary>
        /// Success
        /// </summary>
        Success,

        /// <summary>
        /// Error
        /// </summary>
        Error,

        /// <summary>
        /// Warning
        /// </summary>
        Warning
    }

    public enum AnalyzerFilter
    {
        Address = 1,
        Network = 2,
        Token = 3
    }

    public enum EmailPriority
    {
        High = 1,
        Medium = 2,
        Low = 3
    }

    public enum EnvironmentType
    {
        Local = 1,
        Dev = 2,
        Prod = 3
    }

    public enum MonitoringTypes
    {
        Ethereum = 1,
        Bitcoin = 2,
        Binance = 3
    }

    public enum Currency
    {
        USD = 1
    }

    public enum ApiKeyType
    {
        Etherum = 1,
        BitCoin = 2,
        EthPlorer = 3,
        CryptoCompare = 4
    }

    public enum Direction
    {
        Up = 1,
        Down = 2
    }

}
