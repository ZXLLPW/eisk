using System.Linq;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Data.Metadata.Edm;

namespace Eisk.DataAccessHelpers
{
    public sealed class EntityFrameworkUtility
    {
        public static string GetEntitySetFullName(ObjectContext context, EntityObject entity)
        {
            // If the EntityKey exists, simply get the Entity Set name from the key
            if (entity.EntityKey != null)
            {
                return entity.EntityKey.EntitySetName;
            }
            else
            {
                string entityTypeName = entity.GetType().Name;
                var container = context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
                string entitySetName = (from meta in container.BaseEntitySets
                                        where meta.ElementType.Name == entityTypeName
                                        select meta.Name).First();

                return container.Name + "." + entitySetName;
            }

        }
    }
}
