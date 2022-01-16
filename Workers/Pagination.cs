using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Workers
{
    public class Pagination<T>
    {
        public int CurrentPage { get; set; }
        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int StartItem { get; set; }
        public int EndItem { get; set; }
        public IQueryable<T> Items { get; set; }

        public Pagination(int current_page, int page_size, IQueryable<T> all_items)
        {
            PageSize = page_size;
            TotalItems = all_items.Count();
            TotalPages = (TotalItems % PageSize > 0) ? (TotalItems / PageSize) + 1 : (TotalItems / PageSize);
            CurrentPage = current_page;
            PreviousPage = (CurrentPage > 1) ? CurrentPage - 1 : 1;
            NextPage = (CurrentPage < TotalPages) ? CurrentPage + 1 : TotalPages;
            Items = all_items.Skip((CurrentPage - 1) * PageSize).Take(PageSize);
            if (CurrentPage <= 3)
            {
                StartPage = 1;
                EndPage = TotalPages > 5 ? 5 : TotalPages;
            }
            else if (CurrentPage >= TotalPages - 2)
            {
                StartPage = TotalPages > 5 ? TotalPages - 4 : 1;
                EndPage = TotalPages;
            }
            else
            {
                StartPage = TotalPages > 5 ? CurrentPage - 2 : 1;
                EndPage = TotalPages > 5 ? CurrentPage + 2 : TotalPages;
            }
            StartItem = ((CurrentPage - 1) * PageSize) + 1;
            EndItem = ((CurrentPage - 1) * PageSize) + Items.Count();
        }
    }
}
