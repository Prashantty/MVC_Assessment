using MVC_Assessment.Context;
using MVC_Assessment.Interface;
using MVC_Assessment.Models;

namespace MVC_Assessment.Reopsitory
{
    public class BatchRepository : IBatchInterface
    {
        TravelDbContext _db;
        public BatchRepository(TravelDbContext db)
        {
            _db = db;
        }

        public Batch Create(Batch batch)
        {
            _db.batches.Add(batch); 
            _db.SaveChanges();
            return batch;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Edit(int id, Batch batch)
        {
            throw new NotImplementedException();
        }

        public List<Batch> GetBatch()
        {
            return _db.batches.ToList();
        }

        public Batch GetBatchById(int id)
        {
            return _db.batches.FirstOrDefault(x => x.BatchID == id);
        }
    }
}
