namespace ChartNado.Test
{
    public interface IEntityService
    {
        Entity GetEntityData();
        void UpdateOrCreate(Entity entity);
    }
}