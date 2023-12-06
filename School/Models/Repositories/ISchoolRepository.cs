namespace TP3.Models.Repositories
{
    public interface ISchoolRepository
    {
        IList<School> GetAll();
        School GetById(int id);
        void Add(School sc);
        void Edit(School sc);
        void Delete(School sc);
        double StudentAgeAverage(int schoolId);
        int StudentCount(int schoolId);
    }
}
