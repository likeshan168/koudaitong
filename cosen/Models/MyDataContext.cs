using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Web;

namespace cosen.Models
{
    public partial class DataClassesDataContext : System.Data.Linq.DataContext
    {
        /// <summary>
        /// 重新改造
        /// </summary>
        /// <param name="style_no"></param>
        /// <param name="style_name"></param>
        /// <param name="kucun_num"></param>
        /// <param name="flag"></param>
        /// <param name="page_num"></param>
        /// <returns></returns>
        [ResultType(typeof(kdt_style_kucun_procResult))]
        [ResultType(typeof(int))]
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.kdt_style_kucun_proc")]
        public IMultipleResults kdt_style_kucun_proc2([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "VarChar(30)")] string style_no, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "VarChar(30)")] string style_name, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Decimal(18,0)")] System.Nullable<decimal> kucun_num, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "SmallInt")] System.Nullable<short> flag, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")] System.Nullable<int> page_num)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), style_no, style_name, kucun_num, flag, page_num);
            return ((IMultipleResults)(result.ReturnValue));
        }
    }
}