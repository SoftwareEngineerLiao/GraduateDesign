using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Commons;

namespace Model
{
    /// <summary>
    /// 实体类：LogEntity。
    ///</summary>
    public class LogEntity
    {
        #region 存储字段。
        private int _log_id;
        private string _log_content;
        private DateTime _write_time;
        private int _log_type;
        #endregion

        #region 初始化 log 类的新实例。
        /// <summary>
        /// 初始化 log" /> 类的新实例。
        ///</summary>
        public LogEntity()
        {
            _log_id = 0;
            _log_content = string.Empty;
            _write_time = DateTime.MinValue;
            _log_type = 0;
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public int log_id
        {
            get { return _log_id; }
            set { _log_id = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public string log_content
        {
            get { return _log_content; }
            set { _log_content = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public DateTime write_time
        {
            get { return _write_time; }
            set { _write_time = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public int log_type
        {
            get { return _log_type; }
            set { _log_type = value; }
        }
        #endregion

    }
}