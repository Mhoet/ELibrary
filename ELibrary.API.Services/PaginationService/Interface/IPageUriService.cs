using System;

namespace ELibrary.API.Services.PaginationService.Implementation
{
    public interface IPageUriService
    {
        public Uri GetPageUri(PageFilter filter, string route);
    }
}