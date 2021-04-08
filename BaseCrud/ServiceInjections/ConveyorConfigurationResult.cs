namespace BaseCrud.ServiceInjections
{
    public class ConveyorConfigurationResult
    {
        public bool IsCustomDao { get; set; }
        public bool IsCustomService { get; set; }
        public bool IsCustomValidator { get; set; }
        public ScopeType BaseScopeType { get; set; }
        public bool IsCustomInnerEntitiesHandler { get; set; }
    }
}