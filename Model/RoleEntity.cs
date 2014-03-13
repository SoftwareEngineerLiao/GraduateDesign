using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Commons;

namespace Model
{
    /// <summary>
    /// 实体类：RoleEntity。
    ///</summary>
    [Serializable]
    public class RoleEntity
    {
        #region 存储字段。
        private int _role_id;
        private string _role_name;
        private string _rights_code;
        private DateTime _role_time;
        #endregion

        #region 初始化 role 类的新实例。
        /// <summary>
        /// 初始化 role" /> 类的新实例。
        ///</summary>
        public RoleEntity()
        {
            _role_id = 0;
            _role_name = string.Empty;
            _rights_code = string.Empty;
            _role_time = DateTime.MinValue;
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public int role_id
        {
            get { return _role_id; }
            set { _role_id = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public string role_name
        {
            get { return _role_name; }
            set { _role_name = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public string rights_code
        {
            get { return _rights_code; }
            set { _rights_code = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public DateTime role_time
        {
            get { return _role_time; }
            set { _role_time = value; }
        }
        #endregion

    }
}
