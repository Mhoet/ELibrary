using ELibrary.API.Services.PaginationService.Implementation;
using Microsoft.AspNetCore.WebUtilities;
using System;

namespace ELibrary.API.Services.PaginationService
{
    public class PageUriService : IPageUriService
    {
        private readonly string _baseUri;

        public PageUriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPageUri(PageFilter filter, string route)
        {
            var _endpoint = new Uri(string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(_endpoint.ToString(), "pageNumber", filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}