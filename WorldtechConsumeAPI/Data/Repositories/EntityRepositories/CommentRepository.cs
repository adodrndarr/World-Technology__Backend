using Domain;
using System.Collections.Generic;
using System.Linq;


namespace Data.Repositories.EntityRepositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private WorldtechDbContext _worldtechContext;
        public CommentRepository(WorldtechDbContext worldtechContext)
        {
            this._worldtechContext = worldtechContext;
        }


        public List<Comment> GetAll() => _worldtechContext.Comments.ToList();
    
        public Comment GetById(int id) => _worldtechContext.Comments.SingleOrDefault(comment => comment.Id == id);

        public void Insert(Comment entity) => _worldtechContext.Comments.Add(entity);
        public void Insert(List<Comment> entities) => _worldtechContext.Comments.AddRange(entities);


        public void Update(Comment entity)
        {
            Comment commentToUpdate = GetById(entity.Id);

            if (CommentExists(commentToUpdate))
                _worldtechContext.Comments.Update(commentToUpdate);
        }

        public void DeleteById(int id)
        {
            var commentToDelete = GetById(id);

            if (CommentExists(commentToDelete))
                _worldtechContext.Comments.Remove(commentToDelete);
        }
        public void DeleteEntities(List<Comment> entities) =>  _worldtechContext.Comments.RemoveRange(entities);
        

        public bool CommentExists(Comment comment)
        {
            if (comment != null) return true;

            return false;
        }

        public void Save() => _worldtechContext.SaveChanges();        
    }
}