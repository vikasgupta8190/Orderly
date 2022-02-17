using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Orderly.Models.Extensions
{
    public static class ModelExtensions
    {
        /// <summary>
        /// Prepare passed list model to display in a grid
        /// </summary>
        /// <typeparam name="TListModel">List model type</typeparam>
        /// <typeparam name="TModel">Model type</typeparam>
        /// <typeparam name="TObject">Object type</typeparam>
        /// <param name="listModel">List model</param>
        /// <param name="searchModel">Search model</param>
        /// <param name="objectList">Paged list of objects</param>
        /// <param name="dataFillFunction">Function to populate model data</param>
        /// <returns>List model</returns>
        public static TListModel PrepareToGrid<TListModel, TModel, TObject>(this TListModel listModel,
             BaseSearchModel searchModel, IPagedList<TObject> objectList, Func<IEnumerable<TModel>> dataFillFunction)
             where TListModel : BasePagedListModel<TModel>
             where TModel : BaseEntityModel
        {
            if (listModel == null)
                throw new ArgumentNullException(nameof(listModel));

            listModel.Data = dataFillFunction?.Invoke();
            listModel.Draw = searchModel?.Draw;
            listModel.RecordsTotal = objectList?.TotalCount ?? 0;
            listModel.RecordsFiltered = objectList?.TotalCount ?? 0;

            return listModel;
        }
    }
}
