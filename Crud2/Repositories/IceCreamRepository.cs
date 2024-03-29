using Crud2.Models;

namespace Crud2.Repositories
{
    public class IceCreamRepository : IIceCreamRepository
    {
        private readonly IceCreamContext context;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_context"></param>
        public IceCreamRepository(IceCreamContext _context)
        {
            context = _context;
        }
        /// <summary>
        /// Get all IceCreams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IceCream> GetIceCreams()
        {
            return context.IceCreamItems.AsEnumerable<IceCream>();
        }
        /// <summary>
        /// Get an ice cream based on it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IceCream GetIceCreamById(int id)
        {
            return context.IceCreamItems.Find(id);
        }
        /// <summary>
        /// Insert an Ice cream
        /// </summary>
        /// <param name="iceCream"></param>
        public void InsertIceCream(IceCream iceCream)
        {
            context.IceCreamItems.Add(iceCream);
            context.SaveChanges();
        }
        /// <summary>
        /// Updates an Ice cream
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="newIceCream"></param>
        /// <returns></returns>
        public bool UpdateIceCream(int Id, IceCream newIceCream)
        {
            if (Id == newIceCream.Id)
            {
                context.Entry(newIceCream).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Deletes an Ice cream
        /// </summary>
        /// <param name="iceCreamId"></param>
        /// <returns></returns>
        public bool DeleteIceCream(int iceCreamId)
        {
            IceCream iceCream = GetIceCreamById(iceCreamId);
            if(iceCream != null)
            {
                context.IceCreamItems.Remove(iceCream);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Get all ice creams that matches filter value
        /// </summary>
        /// <param name="filterParameter"></param>
        /// <returns></returns>
        public IEnumerable<IceCream> GetFilteredIceCreams(string filterParameter)
        {
            if(!string.IsNullOrEmpty(filterParameter))
            {
                List<IceCream> iceCreams = GetIceCreams().ToList();
                List<IceCream> filteredIceCreams = new List<IceCream>();
                foreach(IceCream iceCream in iceCreams)
                {
                    if(iceCream.IceCreamType.ToLower().Contains(filterParameter) || iceCream.Natural_synthetic.ToLower().Contains(filterParameter) 
                        || iceCream.IceCreamType.ToLower().Contains(filterParameter) || iceCream.VegType.ToLower().Contains(filterParameter) 
                        || iceCream.Allergens.ToLower().Contains(filterParameter) || iceCream.Brand.ToLower().Contains(filterParameter) || iceCream.EatedBy.ToLower().Contains(filterParameter))
                    {
                        filteredIceCreams.Add(iceCream);
                    }
                }
                return filteredIceCreams;
            }
            else
            {
                return null;
            }
        }

        public bool UploadiceCreamImage(IceCreamImages imgDetail)
        {
            context.IceCreamImages.Add(imgDetail);
            context.SaveChanges();
            return true;
        }
    }
}
