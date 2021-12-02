namespace voresgruppe.ThirdSemesterExamBackend.Security
{
    public interface IAuthDbSeeder
    {
        void SeedDevelopment();
        void SeedProduction();
    }
}