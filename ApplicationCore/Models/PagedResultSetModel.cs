﻿using System;
namespace ApplicationCore.Models
{
	public class PagedResultSetModel<T> where T : class
    {
        public PagedResultSetModel(int pageNumber, int totalRecords, int pageSize, IEnumerable<T> pagedData, int paginationRange)
        {
            PageNumber = pageNumber;
            TotalRecords = totalRecords;
            //PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(TotalRecords / (double)pageSize);
            PagedData = pagedData;
            PaginationRange = paginationRange > TotalPages ? TotalPages : paginationRange;
            PaginationStart = GetPageStart(PageNumber);
        }

        public int PageNumber { get; }
        public int TotalRecords { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public IEnumerable<T> PagedData { get; set; }
        public int PaginationRange { get; }
        public int PaginationStart { get; }

        private int GetPageStart(int currentPage)
        {
            int start = currentPage - (PaginationRange / 2);

            if (currentPage + PaginationRange > TotalPages)
                start = TotalPages - PaginationRange;
            else if (currentPage - PaginationRange < 1)
                start = 1;

            if (start < 1)
                start = 1;

            return start;

        }
    }
}

