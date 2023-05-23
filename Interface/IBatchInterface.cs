using MVC_Assessment.Models;

namespace MVC_Assessment.Interface
{
    public interface IBatchInterface
    {
        List<Batch> GetBatch();
        Batch Create(Batch batch);
        Batch GetBatchById(int id);
        int Edit(int id, Batch batch);
        int Delete(int id);


    }
}
