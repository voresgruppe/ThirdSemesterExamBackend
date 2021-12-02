namespace voresgruppe.ThirdSemesterExamBackend.DataAccess
{
    public interface IMainDbSeeder
    {
        void SeedDevelopment();
        void SeedProduction();
    }
}