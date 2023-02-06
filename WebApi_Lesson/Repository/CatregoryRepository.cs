using WebApi_Lesson.Data;
using WebApi_Lesson.Interface;
using WebApi_Lesson.Models;

namespace WebApi_Lesson.Repository
{
    public class CatregoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CatregoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExist(int id)
        {
            return _context.Categories.Any(p => p.Id == id);
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonsByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(p => p.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}
