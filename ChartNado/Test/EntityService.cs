namespace ChartNado.Test
{
    public class EntityService : IEntityService
    {
        public Entity GetEntityData()
        {
            return new Entity {Data = 10, Name = "some random name"};
        }

        public void UpdateOrCreate(Entity entity)
        {
        }
    }
}