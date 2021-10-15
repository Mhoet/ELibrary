using ELibrary.API.Model.DTO.PaginationDTO;
using ELibrary.API.Services.PaginationService.Implementation;
using System;
using System.Collections.Generic;

namespace ELibrary.Common
{
    public class PaginationHelper
    {
        public static PageResponseDTO<IEnumerable<T>> CreatePagedReponse<T>(List<T> pagedData, PageFilter validFilter, int totalRecords, IPageUriService uriService, string route)
        {
            var respose = new PageResponseDTO<IEnumerable<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            respose.NextPage =
                validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
                ? uriService.GetPageUri(new PageFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
                : null;
            respose.PreviousPage =
                validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
                ? uriService.GetPageUri(new PageFilter(validFilter.PageNumber - 1, validFilter.PageSize), route)
                : null;
            respose.FirstPage = uriService.GetPageUri(new PageFilter(1, validFilter.PageSize), route);
            respose.LastPage = uriService.GetPageUri(new PageFilter(roundedTotalPages, validFilter.PageSize), route);
            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalRecords;
            return respose;
        }

        public static object CreatePagedReponse<T>(List<T> pagedData, PageFilter validFilter, int totalRecords, object pageUriService, string route)
        {
            throw new NotImplementedException();
        }
    }
}