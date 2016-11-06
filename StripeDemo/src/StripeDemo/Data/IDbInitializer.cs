using System.Threading.Tasks;

namespace StripeDemo.Data
{
    public interface IDbInitializer
    {
        void SeedData();
    }
}
