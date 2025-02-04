using Microsoft.EntityFrameworkCore;
using QubitSystem.Data;
using QubitSystem.Persistence.Contracts;
using QubitSystem.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QubitSystem.Persistence
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataDbContext context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(DataDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual async Task<T> Add(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException ex)
            {
                // Log DB-specific exceptions
                Console.Error.WriteLine($"Database update error: {ex.Message}");
                throw new Exception("An error occurred while adding the entity.", ex);
            }
            catch (Exception ex)
            {
                // Handle general unexpected errors
                Console.Error.WriteLine($"Error adding entity: {ex.Message}");
                throw;
            }
        }

        public virtual async Task<bool> Delete(string id)
        {
            try
            {
                var entity = await dbSet.FindAsync(id);
                if (entity == null)
                {
                    throw new KeyNotFoundException($"Entity with ID {id} not found.");
                }

                dbSet.Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                // Handle DB-specific errors (e.g., foreign key constraints)
                Console.Error.WriteLine($"Error deleting entity: {ex.Message}");
                throw new Exception("An error occurred while deleting the entity. It might be referenced by other entities.", ex);
            }
            catch (Exception ex)
            {
                // Handle other unexpected errors
                Console.Error.WriteLine($"Error deleting entity: {ex.Message}");
                throw;
            }
        }

        public virtual async Task<List<T>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync(); // Materializes the query into a List asynchronously
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"Error retrieving entities: {ex.Message}");
                throw new Exception("An error occurred while retrieving entities.", ex);
            }
        }

        public virtual async Task<T> GetById(string id)
        {
            try
            {
                var entity = await dbSet.FindAsync(id);
                if (entity == null)
                {
                    throw new KeyNotFoundException($"Entity with ID {id} not found.");
                }

                return entity;
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                Console.Error.WriteLine($"Error retrieving entity: {ex.Message}");
                throw new Exception("An error occurred while retrieving the entity.", ex);
            }
        }

        public virtual async Task<T> Update(T entity)
        {
            try
            {
                // Ensure the entity has an 'Id' property
                var idProperty = entity.GetType().GetProperty("Id");
                if (idProperty == null)
                {
                    throw new ArgumentException("Entity does not have an 'Id' property.");
                }

                // Get the 'Id' value from the entity
                var idValue = idProperty.GetValue(entity);
                if (idValue == null)
                {
                    throw new ArgumentNullException("The 'Id' property is null.");
                }

                // Ensure the Id is of type int, handle accordingly if different type
                if (!(idValue is string Id))
                {
                    throw new InvalidCastException("The 'Id' property is not of type 'int'.");
                }

                // Find the existing entity
                var existingEntity = await dbSet.FindAsync(Id);
                if (existingEntity == null)
                {
                    throw new KeyNotFoundException($"Entity with ID {Id} not found for update.");
                }

                // Attach the entity and mark it as modified
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;

                // Save changes to the database
                await context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency issues
                Console.Error.WriteLine($"Concurrency error: {ex.Message}");
                throw new Exception("A concurrency error occurred while updating the entity.", ex);
            }
            catch (DbUpdateException ex)
            {
                // Handle DB-specific update errors
                Console.Error.WriteLine($"Database update error: {ex.Message}");
                throw new Exception("An error occurred while updating the entity in the database.", ex);
            }
            catch (ArgumentException ex)
            {
                // Handle argument exception for missing 'Id' property
                Console.Error.WriteLine($"Argument error: {ex.Message}");
                throw new Exception("The entity is missing an 'Id' property.", ex);
            }
            catch (InvalidCastException ex)
            {
                // Handle type casting errors
                Console.Error.WriteLine($"Invalid cast error: {ex.Message}");
                throw new Exception("The 'Id' property is not of the expected type.", ex);
            }
            catch (Exception ex)
            {
                // Handle all other exceptions
                Console.Error.WriteLine($"Error updating entity: {ex.Message}");
                throw;
            }
        }
    }
}
