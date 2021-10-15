using System;

namespace ELibrary.API.Model.DTO.PaginationDTO
{
    public class PageResponseDTO<T> : Response<T>
    {
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }
        public Uri PreviousPage { get; set; }
        public Uri NextPage { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public PageResponseDTO(T data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
        }
    }
}