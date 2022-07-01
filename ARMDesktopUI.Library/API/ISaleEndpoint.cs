using ARMDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace ARMDesktopUI.Library.API
{
    public interface ISaleEndpoint
    {
        Task PostSale(SaleModel sale);
    }
}