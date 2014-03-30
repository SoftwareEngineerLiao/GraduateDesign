using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Commons;

namespace Model
{
    /// <summary>
    /// 实体类：AcademyEntity。
    ///</summary>
    [Serializable]
    public class AcademyEntity
    {
        #region 存储字段。
        private string _academy_no;
        private string _academy_name;
        #endregion

        #region 初始化 academy 类的新实例。
        /// <summary>
        /// 初始化 academy" /> 类的新实例。
        ///</summary>
        public AcademyEntity()
        {
            _academy_no = string.Empty;
            _academy_name = string.Empty;
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public string academy_no
        {
            get { return _academy_no; }
            set { _academy_no = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public string academy_name
        {
            get { return _academy_name; }
            set { _academy_name = value; }
        }
        #endregion

    }
}

