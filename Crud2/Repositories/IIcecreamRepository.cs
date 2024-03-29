using Crud2.Models;

namespace Crud2.Repositories
{
    public interface IIceCreamRepository
    {
        IEnumerable<IceCream> GetIceCreams();
        IceCream GetIceCreamById(int id);
        void InsertIceCream(IceCream iceCream);
        bool UpdateIceCream(int Id, IceCream newIceCream);
        bool DeleteIceCream(int iceCreamId);
        IEnumerable<IceCream> GetFilteredIceCreams(string filterParameter);
        bool UploadiceCreamImage(IceCreamImages imgDetail);
    }
}
