using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Commons;

namespace Model
{
    /// <summary>
    /// 实体类：UserEntity。
    ///</summary>
    public class UserEntity
    {
        #region 存储字段。
        private int _user_id;
        private string _user_name;
        private string _real_name;
        private string _user_pwd;
        private int _status;
        private int _role_id;
        #endregion

        #region 初始化 user 类的新实例。
        /// <summary>
        /// 初始化 user" /> 类的新实例。
        ///</summary>
        public UserEntity()
        {
            _user_id = 0;
            _user_name = string.Empty;
            _real_name = string.Empty;
            _user_pwd = string.Empty;
            _status = 0;
            _role_id = 0;
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public string user_name
        {
            get { return _user_name; }
            set { _user_name = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public string real_name
        {
            get { return _real_name; }
            set { _real_name = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public string user_pwd
        {
            get { return _user_pwd; }
            set { _user_pwd = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public int status
        {
            get { return _status; }
            set { _status = value; }
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

    }
}