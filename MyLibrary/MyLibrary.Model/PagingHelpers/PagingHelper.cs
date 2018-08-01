using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.Model.PagingHelpers
{
    public class PagingHelpers<T>
    {
        /// <summary>
        /// 分页数据源
        /// </summary>
        public IEnumerable<T> DataSource { get;private set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get;private set; }

        /// <summary>
        /// 起始页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get;private set; }

        /// <summary>
        /// 当前页面
        /// </summary>
        public int PageNow { get; set; }
        /// <summary>
        /// 判断是否有前一页
        /// </summary>
        public bool HasPrev { get { return PageIndex > 1; } }

        /// <summary>
        /// 判断是否有后一页
        /// </summary>
        public bool HasNext { get { return PageIndex < PageCount; } }

        /// <summary>
        /// 构造函数，定义了pageSize,dataSource和pageCount的值，另外的pageIndex在控制器定义
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="dataSource"></param>
        public PagingHelpers(int pageSize, IEnumerable<T> dataSource)
        {
            this.PageSize = pageSize > 1 ? pageSize : 1;
            this.DataSource = dataSource;
            PageCount = (int)Math.Ceiling(dataSource.Count() / (double)pageSize);
        }

        public IEnumerable<T> GetPagingData()
        {
            return DataSource.Skip((PageIndex - 1) * PageSize).Take(PageSize);
        }
    }
}