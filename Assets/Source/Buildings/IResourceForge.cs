namespace Source.Buildings
{
    public interface IResourceForge
    {
        public void BuildEnable(bool enable);
        public void SelectResource(string resourceName);
        public void ResourceCreationUpdate();
    }
}