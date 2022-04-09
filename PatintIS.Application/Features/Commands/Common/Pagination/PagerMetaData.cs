using System;
using System.Collections.Generic;
using System.Text;

namespace PatintIS.Application.Features.Commands.Common.Pagination
{
    public class PagerMetaData
    {
        public PagerMetaData(int CurrentPage,int TotalCount,int PageSize)
        {
            this.CurrentPage = CurrentPage;
            this.TotalCount = TotalCount;
            this.PageSize = PageSize;
            TotalPages = (int)Math.Ceiling((double)TotalCount /(double)PageSize);
        }
        public int PageSize { get; set; }
        public int CurrentPage { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}
