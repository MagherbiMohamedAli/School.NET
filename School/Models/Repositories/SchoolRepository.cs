namespace TP3.Models.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        readonly StudentContext context;
        public SchoolRepository(StudentContext context)
        {
            this.context = context;
        }
        public IList<School> GetAll()
        {
            return context.Schools.OrderBy(s => s.SchoolName).ToList();
        }
        public School GetById(int id)
        {
            return context.Schools.Find(id);
        }
        public void Add(School sc)
        {
            context.Schools.Add(sc);
            context.SaveChanges();
        }
        public void Edit(School sc)
        {
            School s1 = context.Schools.Find(sc.SchoolID);
            if (s1 != null)
            {
                s1.SchoolName = sc.SchoolName;
                s1.SchoolAdress = sc.SchoolAdress;
                context.SaveChanges();
            }
        }
    
    public void Delete(School sc)
    {
        School s1 = context.Schools.Find(sc.SchoolID);
        if (s1 != null)
        {
            context.Schools.Remove(s1);
            context.SaveChanges();
        }
    }
    public double StudentAgeAverage(int schoolId)
    {
        if (StudentCount(schoolId) == 0)
            return 0;
        else
            return context.Students.Where(sc => sc.SchoolID ==
            schoolId).Average(e => e.Age);
    }
    public int StudentCount(int schoolId)
    {
        return context.Students.Where(sc => sc.SchoolID ==
        schoolId).Count();
    }
}
}
