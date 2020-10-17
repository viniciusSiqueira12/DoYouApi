using DoYou.Domain.Enums;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoYou.Domain.Entities.Base
{
    public class DataTableBase<T> : Notifiable
    {

        public DataTableBase(string[] sortByOptions, string sortByDefault)
        {
            _SortByOptions = sortByOptions.AsEnumerable<string>().Where(o => typeof(T).GetProperty(o) != null).Select(o => o.ToLower()).ToArray<string>();
            _SortByDefault = sortByDefault.ToLower();
        }

        private string SetSortBy(string sortBy)
        {
            string ret = _SortByDefault;
            if (Array.IndexOf(_SortByOptions, sortBy.ToLower()) != -1)
            {
                ret = sortBy;
            }
            else
            {
                string[] opcoesValidas = _SortByOptions.AsEnumerable<string>().Select(o => o.ToUpper()).ToArray<string>();
                string mensagem = "Campo '" + sortBy + "' é uma opção inválida para ordenação.As opções válidas são: '" + string.Join(",", opcoesValidas) + "'.";
                this.AddNotification("Data Table", mensagem);
            }
            return ret;
        }

        public int PageNumber { get; set; } = 0;
        public int PageView { get; set; } = 5;

        private string _SortBy;
        public string SortBy
        {
            get
            {
                return _SortBy ?? _SortByDefault;
            }
            set
            {
                _SortBy = SetSortBy(value);
            }
        }

        public string Filter { get; set; }
        public EnumTipoDeOrdenacao SortOrder { get; set; } = EnumTipoDeOrdenacao.desc;

        private string[] _SortByOptions { get; set; } = { "Id" };
        private string _SortByDefault { get; set; } = "Id";
    }

    public class DataTableResponseBase<T> where T : EntityBase
    {
        public DataTableResponseBase(int pageSize, int pageView, int pageNumber, IList<T> data)
        {
            PageSize = pageSize;
            PageView = pageView > 0 ? pageView : 5;
            Pages = PageView > 0 ? (pageSize / PageView) : 1;
            PageNumber = pageNumber;
            Data = data ?? Data;
        }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PageView { get; set; }
        public int Pages { get; set; }
        public IList<T> Data { get; set; } = new List<T> { };
    }
}
