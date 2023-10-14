namespace Source.Buildings
{
    public interface IResourceForge
    {
        public void ProcessingToggle();
        public void SelectResource(string resourceName, MakeResource makeResource);
        public void ResourceCreationUpdate();
    }
}